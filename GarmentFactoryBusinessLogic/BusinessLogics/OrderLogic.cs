﻿using System;
using System.Collections.Generic;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.BusinessLogicsContracts;
using GarmentFactoryContracts.Enums;
using GarmentFactoryContracts.StoragesContracts;
using GarmentFactoryContracts.ViewModels;


namespace GarmentFactoryBusinessLogic.BusinessLogics
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderStorage _orderStorage;
        private readonly IWarehouseStorage _warehouseStorage;
        private readonly IGarmentStorage _garmentStorage;
        public OrderLogic(IOrderStorage orderStorage, IWarehouseStorage warehouseStorage, IGarmentStorage garmentStorage)
        {
            _orderStorage = orderStorage;
            _warehouseStorage = warehouseStorage;
            _garmentStorage = garmentStorage;
        }
        public void CreateOrder(CreateOrderBindingModel model)
        {
            _orderStorage.Insert(new OrderBindingModel
            {
                GarmentId = model.GarmentId,
                ClientId = model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
        }

        public void DeliveryOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                GarmentId = order.GarmentId,
                ClientId = order.ClientId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Выдан,
                ImplementerId = order.ImplementerId
            });
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { _orderStorage.GetElement(model) };
            }
            return _orderStorage.GetFilteredList(model);
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            OrderViewModel order = _orderStorage.GetElement(new OrderBindingModel
            {
                Id = model.OrderId
            });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Принят && order.Status != OrderStatus.Требуются_материалы)
            {
                throw new Exception("Заказ еще не принят");
            }
            var updateBindingModel = new OrderBindingModel
            {
                Id = order.Id,
                GarmentId = order.GarmentId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                ClientId = order.ClientId
            };
            if (!_warehouseStorage.TakeTextileFromWarehouse(_garmentStorage.GetElement
      (new GarmentBindingModel { Id = order.GarmentId }).GarmentTextiles, order.Count))
            {
                updateBindingModel.Status = OrderStatus.Требуются_материалы;
            }
            else
            {
                updateBindingModel.DateImplement = DateTime.Now;
                updateBindingModel.Status = OrderStatus.Выполняется;
                updateBindingModel.ImplementerId = model.ImplementerId;
            }

            _orderStorage.Update(updateBindingModel);
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel
            {
                Id = model.OrderId
            });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                GarmentId = order.GarmentId,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Готов
            });
        }
    }
}
