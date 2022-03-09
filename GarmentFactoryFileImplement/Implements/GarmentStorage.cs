﻿using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.StoragesContracts;
using GarmentFactoryContracts.ViewModels;
using GarmentFactoryFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarmentFactoryFileImplement.Implements
{
    public class GarmentStorage : IGarmentStorage
    {
        private readonly FileDataListSingleton source;

        public void Delete(GarmentBindingModel model)
        {
            Garment element = source.Garments.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Garments.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public GarmentStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public GarmentViewModel GetElement(GarmentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var garment = source.Garments
            .FirstOrDefault(rec => rec.GarmentName == model.GarmentName || rec.Id
            == model.Id);
            return garment != null ? CreateModel(garment) : null;
        }

        public List<GarmentViewModel> GetFilteredList(GarmentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Garments
            .Where(rec => rec.GarmentName.Contains(model.GarmentName))
            .Select(CreateModel)
            .ToList();
        }

        public List<GarmentViewModel> GetFullList()
        {
            return source.Garments
            .Select(CreateModel)
            .ToList();
        }

        public void Insert(GarmentBindingModel model)
        {
            int maxId = source.Garments.Count > 0 ? source.Garments.Max(rec => rec.Id)
            : 0;
            var element = new Garment
            {
                Id = maxId + 1,
                GarmentTextiles = new Dictionary<int, int>()
            };
            source.Garments.Add(CreateModel(model, element));
        }

        public void Update(GarmentBindingModel model)
        {
            var element = source.Garments.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }

        private static Garment CreateModel(GarmentBindingModel model, Garment garment)
        {
            garment.GarmentName = model.GarmentName;
            garment.Price = model.Price;
            // удаляем убранные
            foreach (var key in garment.GarmentTextiles.Keys.ToList())
            {
                if (!model.GarmentTextiles.ContainsKey(key))
                {
                    garment.GarmentTextiles.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var textile in model.GarmentTextiles)
            {
                if (garment.GarmentTextiles.ContainsKey(textile.Key))
                {
                    garment.GarmentTextiles[textile.Key] =
                    model.GarmentTextiles[textile.Key].Item2;
                }
                else
                {
                    garment.GarmentTextiles.Add(textile.Key,
                    model.GarmentTextiles[textile.Key].Item2);
                }
            }
            return garment;
        }

        private GarmentViewModel CreateModel(Garment garment)
        {
            return new GarmentViewModel

            {
                Id = garment.Id,
                GarmentName = garment.GarmentName,
                Price = garment.Price,
                GarmentTextiles = garment.GarmentTextiles
            .ToDictionary(recPC => recPC.Key, recPC =>
            (source.Textiles.FirstOrDefault(recC => recC.Id ==
            recPC.Key)?.TextileName, recPC.Value))
            };
        }
    }
}