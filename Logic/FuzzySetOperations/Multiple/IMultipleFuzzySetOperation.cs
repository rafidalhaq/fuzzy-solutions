using System.Collections.Generic;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations.Binary;

namespace IGS.Fuzzy.FuzzySetOperations.Multiple
{
    public interface IMultipleFuzzySetOperation<T> : IBinaryFuzzySetOperation<T>
    {
        /// <summary>
        /// ���������� ��������� ���������� ������������� �������� ��� ����������� ��������� �����������.
        /// </summary>
        /// <param name="sets">���������</param>
        /// <returns>�������������� ���������</returns>
        FuzzySet<T> Operate(IEnumerable<FuzzySet<T>> sets);
    }
}