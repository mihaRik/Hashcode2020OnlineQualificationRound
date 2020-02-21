using Hashcode2020OnlineRound.Entities;
using System;

namespace Hashcode2020OnlineRound
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputType = InputType.Example;
            var data = FileReader.GetLibrariesAsync(inputType).Result;

            var outputs = Logic.Logic.SolutionV5(data);

            FileWriter.ProcessOrderOutputForExcelAsync(outputs, inputType).Wait();

            var inputType1 = InputType.Incunabula;
            var data1 = FileReader.GetLibrariesAsync(inputType1).Result;

            var outputs1 = Logic.Logic.SolutionV5(data1);

            FileWriter.ProcessOrderOutputForExcelAsync(outputs1, inputType1).Wait();
            //////////
            var inputType2 = InputType.LibrariesOfTheWorld;
            var data2 = FileReader.GetLibrariesAsync(inputType2).Result;

            var outputs2 = Logic.Logic.SolutionV5(data2);

            FileWriter.ProcessOrderOutputForExcelAsync(outputs2, inputType2).Wait();
            ///////////
            var inputType3 = InputType.ReadOn;
            var data3 = FileReader.GetLibrariesAsync(inputType3).Result;

            var outputs3 = Logic.Logic.SolutionV5(data3);

            FileWriter.ProcessOrderOutputForExcelAsync(outputs3, inputType3).Wait();
            /////////////
            var inputType4 = InputType.SoManyBooks;
            var data4 = FileReader.GetLibrariesAsync(inputType4).Result;

            var outputs4 = Logic.Logic.SolutionV5(data4);

            FileWriter.ProcessOrderOutputForExcelAsync(outputs4, inputType4).Wait();
            //////////
            var inputType5 = InputType.ToughChoices;
            var data5 = FileReader.GetLibrariesAsync(inputType5).Result;

            var outputs5 = Logic.Logic.SolutionV5(data5);

            FileWriter.ProcessOrderOutputForExcelAsync(outputs5, inputType5).Wait();
        }
    }
}
