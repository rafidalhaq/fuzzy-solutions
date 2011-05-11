using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Relations
{
    public interface IRelation<TItems, TResult>
    {
        /// <summary>
        /// ���������� ��������� ��� ����� ��������� �����������.
        /// </summary>
        /// <param name="first">������ ���������</param>
        /// <param name="second">������ ���������</param>
        /// <returns>�������������� ���������</returns>
        FuzzySet<TResult> Operate(FuzzySet<TItems> first, FuzzySet<TItems> second);
    }
}