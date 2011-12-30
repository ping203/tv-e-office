using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.DataObject;
using System.Reflection;


namespace DataAccess.Common
{
    public class Common
    {
        static List<T> ConvertToList(DataTable dtb)
        {
            List<Object> lstResult=new List<Object>();
            Type ObjType = typeof(Object);
            FieldInfo[] afieldinfo = ObjType.GetFields();
            foreach(DataRow dtr in dtb.Rows)
            {
                
                
            }
            return lstResult;
        }
    }
}
