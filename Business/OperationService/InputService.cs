using System;
using System.Collections.Generic;
using System.Text;
using Business.Interface;

namespace Business.OperationService
{
   public class InputService:IInputService
    {
        private string RoverCommand()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("5 5");
            stringBuilder.AppendLine("1 2 N");
            stringBuilder.AppendLine("M");
            stringBuilder.AppendLine("0 3 N");
            stringBuilder.AppendLine("RMM");
            stringBuilder.AppendLine("2 3 W");
            stringBuilder.AppendLine("MMRM");

            return stringBuilder.ToString();
        }

        private string CaseStudyInputValues()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("5 5");
            stringBuilder.AppendLine("1 2 N");
            stringBuilder.AppendLine("LMLMLMLMM");
            stringBuilder.AppendLine("3 3 E");
            stringBuilder.AppendLine("MMRMMRMRRM");

            return stringBuilder.ToString();
        }

        private string NonPlateauPosition()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("5 5");
            stringBuilder.AppendLine("1 2 N");
            stringBuilder.AppendLine("LMLMLMLMMMMM");
            stringBuilder.AppendLine("3 3 E");
            stringBuilder.AppendLine("MMRMMMMMRMRRM");

            return stringBuilder.ToString();
        }

        private string SameRoverPosition()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("5 5");
            stringBuilder.AppendLine("3 3 E");
            stringBuilder.AppendLine("MMRMMRMRRM");
            stringBuilder.AppendLine("3 3 E");
            stringBuilder.AppendLine("MMRMMRMRRM");

            return stringBuilder.ToString();
        }

        private string InvalidPlateauPosition()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("-5 5");
            stringBuilder.AppendLine("3 3 E");
            stringBuilder.AppendLine("MMRMMRMRRM");
            stringBuilder.AppendLine("3 3 E");
            stringBuilder.AppendLine("MMRMMRMRRM");

            return stringBuilder.ToString();
        }

        private string InvalidRoverPosition()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("5 5");
            stringBuilder.AppendLine("1 3 E");
            stringBuilder.AppendLine("MMRMM RMRRM");
            stringBuilder.AppendLine("3 3 X");
            stringBuilder.AppendLine("MMRMMRMRRM");

            return stringBuilder.ToString();
        }

        private string MissingRoverCommand()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("5 5");
            stringBuilder.AppendLine("1 3 E");
            stringBuilder.AppendLine("3 3 N");
            stringBuilder.AppendLine("MMRMMRMRRM");

            return stringBuilder.ToString();
        }

        private string MissingRoverParameters()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("5 5");

            return stringBuilder.ToString();
        }

        public string GetInputValues()
        {
            return CaseStudyInputValues();
        }
    }
}
