using NUnit.Framework;

namespace Lv1Ls1
{
    [TestFixture]
    public class UnitTest1
    {
        List<User> adminsJSON = new List<User>();
        List<User> adminsYAML = new List<User>();
        List<User> regularsJSON = new List<User>();
        List<User> regularsYAML = new List<User>();

        [SetUp]
        public void getdata()
        {
            //�������� ��������������� ������� �� ������
        }


        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        public void IsUsers()
        {
           //��������� ������������ ������, ������� id � name
        }

        [TestCase]
        [TestCase]
        public void IsFilesEq()
        {
            //����������� ��������������� �������� ��������
        }
    }

    public class User
    {
        public int Id;
        public string Name;
    }
}   