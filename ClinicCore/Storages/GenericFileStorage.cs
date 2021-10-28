using ClinicCore.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ClinicCore.Storages
{
    public class GenericFileStorage<T> : IGenericStorage<T> where T : Entity
    {
        protected string fileLocation;
        public List<T> GetAll()
        {
            String text = File.ReadAllText(this.fileLocation);
            List<T> objects = JsonConvert.DeserializeObject<List<T>>(text);
            return objects;
        }
        public void Add(T newObject)
        {
            List<T> objects = GetAll();

            objects.Add(newObject);
            SaveAll(objects);
        }

        public void Delete(T selectedObject)
        {
            List<T> objects = GetAll();
            foreach (T obj in objects)
            {
                if (obj.Id == selectedObject.Id)
                {                
                    objects.Remove(obj); 
                    break;
                }
            }
            SaveAll(objects);
        }

        public T GetById(int id)
        {
            T findObj = null;
            List<T> objects = GetAll();
            foreach (T obj in objects)
            {
                if (obj.Id == id)
                {
                    findObj = obj;
                }
            }
            return findObj;
        }

        public void Update(T selectedObject)
        {
            List<T> objects = GetAll();
            foreach (T obj in objects)
            {
                if (obj.Id == selectedObject.Id)
                {
                    int index = objects.IndexOf(obj);
                    objects.Remove(obj);
                    objects.Insert(index, selectedObject);
                    break;
                }
            }
            SaveAll(objects);
        }

        public void SaveAll(List<T> objects)
        {
            var file = JsonConvert.SerializeObject(objects, Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(this.fileLocation))
            {
                writer.Write(file);
            }
        }

    }
}
