using System.IO;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Phase04
{

    class DataManager
    {
        private string jsonData {get; set;}

        public List<Student> getData ()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var r = ser.Deserialize<List<Student>>(jsonData);
        }

    }
}