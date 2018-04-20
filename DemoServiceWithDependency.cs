using System.Collections;

namespace UnitTestingDemoApplication.Tests
{
    public class DemoServiceWithDependency
    {
        private readonly IList _iList;

        public DemoServiceWithDependency(IList iList)
        {
            _iList = iList;
        }

        public int Add(object content)
        {
            return _iList.Add(content);
        }

        public void AddRange(IList content)
        {
            foreach (var item in content)
            {
                _iList.Add(item);
            }
        }

        public bool Contains(object subString)
        {
            return _iList.Contains(subString);
        }

        public int GetLength()
        {
            return _iList.Count;
        }
    }
}
