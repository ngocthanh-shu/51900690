using CAIT.SQLHelper;
using Lab3_51900690.Const;
using Lab3_51900690.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_51900690.Repositories
{
    public class LaptopRes
    {
        public static List<Laptop> GetAll()
        {
            object[] value = { };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Laptop_GetAll", value);
            List<Laptop> lstResult = new List<Laptop>();
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    Laptop lap = new Laptop();

                    lap.ID = dr["ID"].ToString();
                    lap.name = dr["Name"].ToString();
                    lap.price = string.IsNullOrEmpty(dr["Price"].ToString()) ? 0 : int.Parse(dr["Price"].ToString());
                    lap.ram = string.IsNullOrEmpty(dr["RAM"].ToString()) ? 0 : int.Parse(dr["RAM"].ToString());
                    lap.storage = string.IsNullOrEmpty(dr["Storage"].ToString()) ? 0 : int.Parse(dr["Storage"].ToString());
                    lap.cpu = dr["CPU"].ToString();

                    lstResult.Add(lap);
                }
            }
            return lstResult;
        }

        public static Laptop GetByID(string ID)
        {
            Laptop item = new Laptop();
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            object[] value = { ID };
            DataTable result = connection.Select("Laptop_GetByID",value);
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                item = SQLCommand.Map<Laptop>(result.Rows[0]);
            }
            return item;
        }

        public static Laptop InsertLaptop(Laptop laptop)
        {
            Laptop item = new Laptop();
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            object[] value = { laptop.ID, laptop.name, laptop.price, laptop.ram, laptop.storage,laptop.cpu };
            DataTable result = connection.Select("Laptop_Insert", value);
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                item = SQLCommand.Map<Laptop>(result.Rows[0]);
            }
            return item;
        }

        public static Laptop EditByIDs(Laptop laptop)
        {
            Laptop item = new Laptop();
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            object[] value = { laptop.ID, laptop.name, laptop.price, laptop.ram, laptop.storage, laptop.cpu };
            DataTable result = connection.Select("Laptop_Update", value);
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                item = SQLCommand.Map<Laptop>(result.Rows[0]);
            }
            return item;
        }

        public static Laptop DeleteByID(string id)
        {
            Laptop item = new Laptop();
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            object[] value = { id };
            DataTable result = connection.Select("Laptop_DeleteByID",value);
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                item = SQLCommand.Map<Laptop>(result.Rows[0]);
            }
            return item;
        }
    }
}
