﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BaseModel
    {
        public int ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public DateTime CreateTime
        {
            get;
            set;
        }
        public int CreatorId
        {
            get;
            set;
        }
        public int LastModifierId
        {
            get;
            set;
        }
        public DateTime LastModifyTime
        {
            get;
            set;
        }
    }
}
