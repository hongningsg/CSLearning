using System;
using System.Collections.Generic;
using System.Text;

namespace CSLearning.Model
{
    public class Scalar
    {
        #region properties
        public Type Dtype { get; private set; }
        public object Data { get; private set; }
        #endregion

        #region constructors

        public Scalar(object data)
        {
            SetData(data);
        }
        #endregion

        #region methods
        public Scalar AsType<T>()
        {
            if(typeof(T) == typeof(int))
            {
                return ToInt();
            }
            else if (typeof(T) == typeof(double))
            {
                return ToDouble();
            }
            else if(typeof(T) == typeof(int))
            {
                return ToFloat();
            }
            else
            {
                throw new TypeAccessException($"Type of {typeof(T)} is not a valid scalar type.");
            }
        }

        public Scalar ToDouble()
        {
            return new Scalar(Convert.ToDouble(Data));
        }

        public Scalar ToInt()
        {
            return new Scalar(Convert.ToInt32(Data));
        }

        public Scalar ToFloat()
        {
            return new Scalar((float)Data);
        }

        public void SetData(object data)
        {
            Dtype = data.GetType();
            Data = data;
        }
        #endregion
    }
}
