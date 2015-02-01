﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json2DataSet
{
    public static class Json2DataSetConverter
    {
        private static readonly DataSetBuildVisitor visitor = new DataSetBuildVisitor();
        public static DataSet Convert(string json)
        {
            var token = (JToken)JsonConvert.DeserializeObject(json);
            visitor.Visit(token);
            return visitor.DataSet;
        }

        public static DataSet Convert(string json, ConvertOptions options)
        {
            var token = (JToken)JsonConvert.DeserializeObject(json);
            var thisVisitor = new DataSetBuildVisitor(options);
            thisVisitor.Visit(token);
            return thisVisitor.DataSet;
        }
    }
}
