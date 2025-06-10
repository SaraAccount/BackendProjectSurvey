﻿using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public eTypeTag TypeTag { get; set; }
        public bool IsRequired { get; set; }
        public string Options { get; set; }
    }
}
