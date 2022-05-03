﻿using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.StoragesContracts;
using GarmentFactoryContracts.ViewModels;
using GarmentFactoryDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarmentFactoryDatabaseImplement.Implements
{

    public class ImplementerStorage : IImplementerStorage
    {
        public void Delete(ImplementerBindingModel model)
        {
            using var context = new GarmentFactoryDatabase();
            Implementer element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Implementers.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Исполнитель не найден");
            }
        }

        public ImplementerViewModel GetElement(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GarmentFactoryDatabase();
            var implementer = context.Implementers.Include(x => x.Orders)
            .FirstOrDefault(rec => rec.Id == model.Id || rec.ImplementerFIO == model.ImplementerFIO);
            return implementer != null ?
            new ImplementerViewModel
            {
                Id = implementer.Id,
                ImplementerFIO = implementer.ImplementerFIO,
                WorkingTime = implementer.WorkingTime,
                PauseTime = implementer.PauseTime
            } :
            null;
        }

        public List<ImplementerViewModel> GetFilteredList(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new GarmentFactoryDatabase();
            return context.Implementers.Include(x => x.Orders)
            .Where(rec => rec.ImplementerFIO == model.ImplementerFIO)
            .Select(rec => new ImplementerViewModel
            {
                Id = rec.Id,
                ImplementerFIO = rec.ImplementerFIO,
                WorkingTime = rec.WorkingTime,
                PauseTime = rec.PauseTime
            })
            .ToList();
        }

        public List<ImplementerViewModel> GetFullList()
        {
            using var context = new GarmentFactoryDatabase();
            return context.Implementers.Select(rec => new ImplementerViewModel
            {
                Id = rec.Id,
                ImplementerFIO = rec.ImplementerFIO,
                WorkingTime = rec.WorkingTime,
                PauseTime = rec.PauseTime
            })
            .ToList();
        }

        public void Insert(ImplementerBindingModel model)
        {
            using var context = new GarmentFactoryDatabase();
            context.Implementers.Add(CreateModel(model, new Implementer()));
            context.SaveChanges();
        }

        public void Update(ImplementerBindingModel model)
        {
            using var context = new GarmentFactoryDatabase();
            var element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Исполнитель не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        private Implementer CreateModel(ImplementerBindingModel model, Implementer implementer)
        {
            implementer.ImplementerFIO = model.ImplementerFIO;
            implementer.WorkingTime = model.WorkingTime;
            implementer.PauseTime = model.PauseTime;
            return implementer;
        }
    }
}