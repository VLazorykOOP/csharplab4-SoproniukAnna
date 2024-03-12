using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    internal class VectorFloat
    {
        //поля
        protected float[] FArray;
        protected uint num;
        protected int codeError;
        protected static uint num_vec;

        //конструктори
        // Конструктор без параметрів
        public VectorFloat()
        {
            num = 1;
            FArray = new float[num];
            FArray[0] = 0;
            codeError = 0;
            num_vec++;
        }

        // Конструктор з одним параметром - розмір вектора
        public VectorFloat(uint size)
        {
            num = size;
            FArray = new float[num];
            for (int i = 0; i < num; i++)
            {
                FArray[i] = 0;
            }
            codeError = 0;
            num_vec++;
        }

        // Конструктор із двома параметрами - розмір вектора та значення ініціалізації
        public VectorFloat(uint size, float initValue)
        {
            num = size;
            FArray = new float[num];
            for (int i = 0; i < num; i++)
            {
                FArray[i] = initValue;
            }
            codeError = 0;
            num_vec++;
        }

        //деструктор
        ~VectorFloat()
        {
            Console.WriteLine("Деструктор вектора викликаний.");
        }



        // Властивість, що повертає розмірність вектора (доступна тільки для читання)
        public uint Size
        {
            get { return num; }
        }

        // Властивість для доступу до поля codeError (доступна для читання і запису)
        public int ErrorCode
        {
            get { return codeError; }
            set { codeError = value; }
        }



        // Індексатор
        public float this[int index]
        {
            get
            {
                if (index < 0 || index >= num)
                {
                    codeError = -1;
                    return 0;
                }
                else
                    return FArray[index];
            }
            set
            {
                if (index < 0 || index >= num)
                    codeError = -1;
                else
                    FArray[index] = value;
            }
        }



        // Метод для введення елементів вектора з клавіатури
        public void InputElements()
        {
            Console.WriteLine("Введіть елементи вектора:");
            for (int i = 0; i < num; i++)
            {
                Console.Write($"Елемент {i + 1}: ");
                FArray[i] = float.Parse(Console.ReadLine());
            }
        }

        // Метод для виведення елементів вектора на екран
        public void DisplayElements()
        {
            Console.WriteLine("Елементи вектора:");
            for (int i = 0; i < num; i++)
                Console.WriteLine($"Елемент {i + 1}: {FArray[i]}");
        }

        // Метод для присвоєння елементам масиву вектора деякого значення
        public void AssignElements(float value)
        {
            for (int i = 0; i < num; i++)
                FArray[i] = value;
        }

        // Статичний метод, що підраховує кількість векторів даного типу
        public static uint CountVectors()
        {
            return num_vec;
        }

        // Метод для присвоєння елементам масиву вектора деякого значення (параметр)
        public void AssignElementsWithParameter(float value)
        {
            for (int i = 0; i < num; i++)
                FArray[i] = value;
        }



        // Перевантаження унарних операцій ++ і --
        public static VectorFloat operator ++(VectorFloat vector)
        {
            for (int i = 0; i < vector.num; i++)
                vector.FArray[i]++;
            return vector;
        }

        public static VectorFloat operator --(VectorFloat vector)
        {
            for (int i = 0; i < vector.num; i++)
                vector.FArray[i]--;
            return vector;
        }


        // Перевантаження сталих true і false
        public static bool operator true(VectorFloat vector)
        {
            return vector.num != 0 && !Array.TrueForAll(vector.FArray, element => element == 0);
        }

        public static bool operator false(VectorFloat vector)
        {
            return vector.num == 0 || Array.TrueForAll(vector.FArray, element => element == 0);
        }


        // Перевантаження унарної логічної операції !
        public static VectorFloat operator !(VectorFloat vector)
        {
            vector.codeError = vector.num == 0 ? -1 : 0;
            return vector;
        }


        // Перевантаження унарної побітової операції ~
        public static VectorFloat operator ~(VectorFloat vector)
        {
            for (int i = 0; i < vector.num; i++)
                vector.FArray[i] = ~((int)vector.FArray[i]);
            return vector;
        }

        // Перевантаження арифметичних бінарних операцій + a(i)
        public static VectorFloat operator +(VectorFloat v1, VectorFloat v2)
        {
            if (v1.num != v2.num)
            {
                v1.codeError = -1;
                return v1;
            }

            VectorFloat result = new VectorFloat(v1.num);

            for (int i = 0; i < v1.num; i++)
                result.FArray[i] = v1.FArray[i] + v2.FArray[i];

            return result;
        }

        // Перевантаження арифметичних бінарних операцій + a(ii)
        public static VectorFloat operator +(VectorFloat vector, float scalar)
        {
            VectorFloat result = new VectorFloat(vector.num);

            for (int i = 0; i < vector.num; i++)
                result.FArray[i] = vector.FArray[i] + scalar;

            return result;
        }


        // Перевантаження арифметичних бінарних операцій - b(i)
        public static VectorFloat operator -(VectorFloat v1, VectorFloat v2)
        {
            if (v1.num != v2.num)
            {
                v1.codeError = -1;
                return v1;
            }

            VectorFloat result = new VectorFloat(v1.num);

            for (int i = 0; i < v1.num; i++)
                result.FArray[i] = v1.FArray[i] - v2.FArray[i];

            return result;
        }

        // Перевантаження арифметичних бінарних операцій - b(ii)
        public static VectorFloat operator -(VectorFloat vector, float scalar)
        {
            VectorFloat result = new VectorFloat(vector.num);

            for (int i = 0; i < vector.num; i++)
                result.FArray[i] = vector.FArray[i] - scalar;

            return result;
        }


        // Перевантаження арифметичних бінарних операцій * c(i)
        public static VectorFloat operator *(VectorFloat v1, VectorFloat v2)
        {
            if (v1.num != v2.num)
            {
                v1.codeError = -1;
                return v1;
            }

            VectorFloat result = new VectorFloat(v1.num);

            for (int i = 0; i < v1.num; i++)
                result.FArray[i] = v1.FArray[i] * v2.FArray[i];

            return result;
        }

        // Перевантаження арифметичних бінарних операцій * c(ii)
        public static VectorFloat operator *(VectorFloat vector, float scalar)
        {
            VectorFloat result = new VectorFloat(vector.num);

            for (int i = 0; i < vector.num; i++)
                result.FArray[i] = vector.FArray[i] * scalar;

            return result;
        }


        // Перевантаження арифметичних бінарних операцій / d(i)
        public static VectorFloat operator /(VectorFloat v1, VectorFloat v2)
        {
            if (v1.num != v2.num)
            {
                v1.codeError = -1;
                return v1;
            }

            VectorFloat result = new VectorFloat(v1.num);

            for (int i = 0; i < v1.num; i++)
            {
                if (v2.FArray[i] == 0)
                {
                    v2.codeError = -2;
                    break;
                }
                result.FArray[i] = v1.FArray[i] / v2.FArray[i];
            }
            return result;
        }

        // Перевантаження арифметичних бінарних операцій / d (ii)
        public static VectorFloat operator /(VectorFloat vector, float scalar)
        {
            VectorFloat result = new VectorFloat(vector.num);

            for (int i = 0; i < vector.num; i++)
            {
                if (scalar == 0)
                    break;
                result.FArray[i] = vector.FArray[i] / scalar;
            }

            return result;
        }


        // Перевантаження арифметичних бінарних операцій % e(i)
        public static VectorFloat operator %(VectorFloat v1, VectorFloat v2)
        {
            if (v1.num != v2.num)
            {
                v1.codeError = -1;
                return v1;
            }

            VectorFloat result = new VectorFloat(v1.num);

            for (int i = 0; i < v1.num; i++)
            {
                if (v2.FArray[i] == 0)
                {
                    v2.codeError = -2;
                    break;
                }
                result.FArray[i] = v1.FArray[i] % v2.FArray[i];
            }
            return result;
        }

        // Перевантаження арифметичних бінарних операцій % e (ii)
        public static VectorFloat operator %(VectorFloat vector, float scalar)
        {
            VectorFloat result = new VectorFloat(vector.num);

            for (int i = 0; i < vector.num; i++)
            {
                if (scalar == 0)
                    break;
                result.FArray[i] = vector.FArray[i] % scalar;
            }

            return result;
        }



        // Перевантаження побітових операцій | a(i)
        public static VectorFloat operator |(VectorFloat vector1, VectorFloat vector2)
        {
            if (vector1.num != vector2.num)
            {
                vector1.codeError = -1;
                return vector1;
            }

            VectorFloat result = new VectorFloat(vector1.num);

            for (int i = 0; i < vector1.num; i++)
                result.FArray[i] = (byte)vector1.FArray[i] | (byte)vector2.FArray[i];

            return result;
        }

        // Перевантаження побітових операцій | a(ii)
        public static VectorFloat operator |(VectorFloat vector, byte scalar)
        {
            VectorFloat result = new VectorFloat(vector.num);

            for (int i = 0; i < vector.num; i++)
                result.FArray[i] = (byte)vector.FArray[i] | scalar;

            return result;
        }

        // Перевантаження побітових операцій ^ b(i)
        public static VectorFloat operator ^(VectorFloat vector1, VectorFloat vector2)
        {
            if (vector1.num != vector2.num)
            {
                vector1.codeError = -1;
                return vector1;
            }

            VectorFloat result = new VectorFloat(vector1.num);

            for (int i = 0; i < vector1.num; i++)
                result.FArray[i] = (byte)vector1.FArray[i] ^ (byte)vector2.FArray[i];

            return result;
        }

        // Перевантаження побітових операцій ^ b(ii)
        public static VectorFloat operator ^(VectorFloat vector, byte scalar)
        {
            VectorFloat result = new VectorFloat(vector.num);

            for (int i = 0; i < vector.num; i++)
                result.FArray[i] = (byte)vector.FArray[i] ^ scalar;

            return result;
        }

        // Перевантаження побітових операцій & c(i)
        public static VectorFloat operator &(VectorFloat vector1, VectorFloat vector2)
        {
            if (vector1.num != vector2.num)
            {
                vector1.codeError = -1;
                return vector1;
            }

            VectorFloat result = new VectorFloat(vector1.num);

            for (int i = 0; i < vector1.num; i++)
                result.FArray[i] = (byte)vector1.FArray[i] & (byte)vector2.FArray[i];

            return result;
        }

        // Перевантаження побітових операцій & c(ii)
        public static VectorFloat operator &(VectorFloat vector, byte scalar)
        {
            VectorFloat result = new VectorFloat(vector.num);

            for (int i = 0; i < vector.num; i++)
                result.FArray[i] = (byte)vector.FArray[i] & scalar;

            return result;
        }

        // Перевантаження побітових операцій >> d(i)
        /*public static VectorFloat operator >>(VectorFloat vector1, VectorFloat vector2)
        {
            if (vector1.num != vector2.num)
            {
                vector1.codeError = -1;
                return vector1;
            }

            VectorFloat result = new VectorFloat(vector1.num);

            for (int i = 0; i < vector1.num; i++)
                result.FArray[i] = (byte)vector1.FArray[i] >> (byte)vector2.FArray[i];

            return result;
        }

        // Перевантаження побітових операцій >> d(ii)
        public static VectorFloat operator >>(VectorFloat vector, uint scalar)
        {
            VectorFloat result = new VectorFloat(vector.num);

            for (int i = 0; i < vector.num; i++)
                result.FArray[i] = (byte)vector.FArray[i] >> scalar;

            return result;
        }

        // Перевантаження побітових операцій << e(i)
        public static VectorFloat operator <<(VectorFloat vector1, VectorFloat vector2)
        {
            if (vector1.num != vector2.num)
            {
                vector1.codeError = -1;
                return vector1;
            }

            VectorFloat result = new VectorFloat(vector1.num);

            for (int i = 0; i < vector1.num; i++)
                result.FArray[i] = (byte)vector1.FArray[i] << (byte)vector2.FArray[i];

            return result;
        }

        // Перевантаження побітових операцій << e(ii)
        public static VectorFloat operator <<(VectorFloat vector, uint scalar)
        {
            VectorFloat result = new VectorFloat(vector.num);

            for (int i = 0; i < vector.num; i++)
                result.FArray[i] = (byte)vector.FArray[i] << scalar;

            return result;
        }*/

        // Перевантаження бінарної операції рівності
        public static bool operator ==(VectorFloat vector1, VectorFloat vector2)
        {
            if (ReferenceEquals(vector1, vector2))
                return true;

            if (vector1 is null || vector2 is null)
                return false;

            if (vector1.num != vector2.num)
                return false;

            for (int i = 0; i < vector1.num; i++)
                if (vector1.FArray[i] != vector2.FArray[i])
                    return false;

            return true;
        }

        // Перевантаження бінарної операції нерівності
        public static bool operator !=(VectorFloat vector1, VectorFloat vector2)
        {
            return !(vector1 == vector2);
        }

        // Перевантаження бінарних операцій порівняння
        // Перевантаження >
        public static bool operator >(VectorFloat vector1, VectorFloat vector2)
        {
            if (vector1.num != vector2.num)
            {
                vector1.codeError = -1;
                return false;
            }

            for (int i = 0; i < vector1.num; i++)
                if (vector1.FArray[i] <= vector2.FArray[i])
                    return false;

            return true;
        }

        // Перевантаження >=
        public static bool operator >=(VectorFloat vector1, VectorFloat vector2)
        {
            if (vector1.num != vector2.num)
            {
                vector1.codeError = -1;
                return false;
            }

            for (int i = 0; i < vector1.num; i++)
                if (vector1.FArray[i] < vector2.FArray[i])
                    return false;

            return true;
        }

        // Перевантаження <
        public static bool operator <(VectorFloat vector1, VectorFloat vector2)
        {
            if (vector1.num != vector2.num)
            {
                vector1.codeError = -1;
                return false;
            }

            for (int i = 0; i < vector1.num; i++)
                if (vector1.FArray[i] >= vector2.FArray[i])
                    return false;

            return true;
        }

        // Перевантаження <=
        public static bool operator <=(VectorFloat vector1, VectorFloat vector2)
        {
            if (vector1.num != vector2.num)
            {
                vector1.codeError = -1;
                return false;
            }

            for (int i = 0; i < vector1.num; i++)
                if (vector1.FArray[i] > vector2.FArray[i])
                    return false;

            return true;
        }
    }
}