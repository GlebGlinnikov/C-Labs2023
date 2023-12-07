namespace Lab2.Tests
{
    public class UnitTest1
    {
        //Lab2 Tests
        [Fact]
        public void SolveLinearTest()
        {
            double[] arr = { -2.0 };
            Assert.Equal(arr, EquationSolver.SolveLinear(5, 10));
        }

        [Fact]
        public void SolveQuadraticTest()
        {
            double[] arr = {1, -3};
            Assert.Equal(arr, EquationSolver.SolveQuadratic(1, 2, -3));
        }

        [Fact]
        public void AddGetMarkListTest()
        {
            Mark m = new Mark(1, 2, -3);
            MarkList ML = new MarkList();
            ML.add(1, 2, -3);
            Assert.True(Equal(m, ML.GetMark(0)));
        }

        [Fact]
        public void MarkListEmptyLengthTest()
        {
            MarkList ML = new MarkList();
            Assert.Equal(0, ML.getlength());
        }

        //Lab3 Tests
        [Fact]
        public void serializeJsonTest()
        {
            String filepath = "D:\\Study\\Prog\\Lab2\\Lab2\\history.txt";
            Mark m = new Mark(1, 2, -3);
            m.serializeToJson(filepath);
            Assert.True(Equal(m, Program.deserializeFromJson(filepath)));
        }

        [Fact]
        public void serializeSqlTest()
        {
            Program.history = new MarkList();
            Mark m = new Mark(1, -2, 3);
            Program.history.add(m);
            Program.exportToSql(0);
            Assert.True(Equal(m, Program.importFromSql(0)));
        }

        [Fact]
        public void serializeXMLTest()
        {
            String filepath = "D:\\Study\\Prog\\Lab2\\Lab2\\history.txt";
            Mark m = new Mark(1, 2, -3);
            m.serializeToXml(filepath);
            Assert.True(Equal(m, Program.deserializeFromXml(filepath)));
        }

        private bool Equal(Mark m, Mark m2)
        {
            if (m.a == m2.a && m.b == m2.b && m.c == m2.c)
                return true;
            else 
                return false;
        }

        //Lab4 Tests
        [Fact]
        public void AddGetWebControllerTest()
        {
            Mark m = new Mark(1, 2, -3);
            Controller cont = new Controller();
            cont.AddMark(1, 2, -3);
            Assert.True(Equal(m, cont.GetMark(0)));
        }
    }
}