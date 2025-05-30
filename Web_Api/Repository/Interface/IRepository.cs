﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRepository<T>
    {
        T GetById(int id);
        List<T> GetAll();   
        T AddItem(T item);
        void DeleteItem(int id);
        void UpdateItem(T item);    
    }

}
