using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CSLearning.Model
{
    class Tensor: IEnumerable
    {
        #region field
        private Scalar[] scalars;
        private Tensor[] tensors;
        #endregion

        #region properties
        public Type Dtype { get; private set; }
        public int Dimension { get; private set; }
        public object Value
        {
            get
            {
                if(Dimension == 1)
                {
                    return scalar;
                }
                else
                {
                    return tensors;
                }
            }
            set
            {
                if (Dimension == 1 && typeof(Scalar) == value.GetType())
                {
                    scalars = (Scalar[])value;
                }
                else if (typeof(Tensor) == value.GetType())
                {
                    tensors = (Tensor[])value;
                }
                else
                {
                    throw new TypeAccessException($"Type of {value.GetType()} is not a valid scalar type.");
                }
            }
        }
        #endregion

        #region constructors
        public Tensor()
        {
            
        }

        public IEnumerator GetEnumerator()
        {
            if(Dimension == 1)
            {
                yield return scalars;
            }
            else
            {
                yield return tensors;
            }
            
        }

        #endregion
    }
}
