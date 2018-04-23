using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCxGridViewDataBinding.Models
{
    public class MyModel
    {
        public MyModel()
            : this(0)
        {

        }
        public MyModel(int index)
        {
            ModelID = index;
            ModelName = "Name" + index;
            if (index % 20 == 0)
            {

                ModelState = null;
                return;
            }
            if (index % 10 == 0)
            {
                ModelState = ModelStateEnum.None;
                return;
            }
            if (index % 2 == 0)
                ModelState = ModelStateEnum.NonImportant;
            else
                ModelState = ModelStateEnum.Important;
           
        }
        // Fields...
        private int _ModelID;
        private string _ModelName;
        private ModelStateEnum? _ModelState;
      

        public int ModelID
        {
            get { return _ModelID; }
            set { _ModelID = value; }
        }
        public string ModelName
        {
            get { return _ModelName; }
            set { _ModelName = value; }
        }
        public ModelStateEnum? ModelState
        {
            get { return _ModelState; }
            set { _ModelState = value; }
        }      
        public static List<MyModel> GetModelList()
        {
            List<MyModel> l = new List<MyModel>();
            for (int i = 0; i < 10000; i++)
            {
                l.Add(new MyModel(i));
            }
            return l;
        }
        public static void UpdateModel(List<MyModel> l, MyModel m)
        {

            MyModel editedModel = l.Where(x => x.ModelID == m.ModelID).First();
            editedModel.ModelName = m.ModelName;
            editedModel.ModelState = m.ModelState;
        }
        public static void DeleteModel(List<MyModel> l, int mID)
        {
            l.Remove(l.Where(x => x.ModelID == mID).First());
        }
        public static void InsertModel(List<MyModel> l, MyModel m)
        {
            m.ModelID = l.Count + 1;
            l.Add(m);
        }
    public  enum ModelStateEnum
        {
            None = 2,
            Important = 1,
            NonImportant = 0
        };
    }
}