using MarsOver.Domain.Entity;
using MarsOver.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Assembler
{

    public class InputModelAssembler : IInputModelAssembler
    {
        public InputObject InputModel(string inputValues)
        {
            if (string.IsNullOrEmpty(inputValues))
            {
                throw new CustomException("input value can not be empty");
            }

            InputObject inputModel = new InputObject();

            inputModel.RoverList = new List<Rover>();

            var rows = GetRows(inputValues);

            var plateue = rows.First();

            Position _plateuePosition = new Position
            {
                X = TryParseInt(plateue.Substring(0, 1)),
                Y = TryParseInt(plateue.Substring(1, 1))
            };

            inputModel.Plateau = new Plateau { PlateauPosition = _plateuePosition };

            for (int i = 1; i < rows.Length; i++)
            {
                if ((i % 2) - 1 == 0)
                {
                    char[] roverPosition = rows[i].ToCharArray();

                    if (roverPosition.Length != 3)
                    {
                        throw new CustomException("Rover position is not in the expected format!!");
                    }

                    inputModel.RoverList.Add(new Rover
                    {
                        RoverGuid = Guid.NewGuid(),
                        RoverPosition = new RoverPosition
                        {
                            X = TryParseInt(roverPosition[0].ToString()),
                            Y = TryParseInt(roverPosition[1].ToString()),
                            CurrentDirectionType = MapDirectionType(roverPosition[2].ToString()),
                        },
                        CommandParameters = rows[i + 1]
                    });
                }
            }

            return inputModel;
        }



        private DestinationType MapDirectionType(string direction)
        {
            switch (direction)
            {
                case "N":
                    return DestinationType.North;
                case "S":
                    return DestinationType.South;
                case "E":
                    return DestinationType.East;
                case "W":
                    return DestinationType.West;
                default:
                    return DestinationType.West;
                    //throw new TechnicalException(TechnicalExceptionCode.UnexpectedDirectionType.GetHashCode());
            }
        }

        private string[] GetRows(string inputValues)
        {
            string[] rows = inputValues.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if (rows == null || rows.Length == 0)
            {
                //throw new TechnicalException(TechnicalExceptionCode.InputValuesAreIncorrect.GetHashCode());
            }

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i] = RemoveWhitespace(rows[i]).ToUpper();
            }

            return rows;
        }

        private int TryParseInt(string value)
        {
            int parsedValue;

            bool result = int.TryParse(value, out parsedValue);

            if (result == false)
            {
                //throw new TechnicalException(TechnicalExceptionCode.ParsedValueParameterIsIncorrect.GetHashCode());
            }

            return parsedValue;
        }

        private string RemoveWhitespace(string text)
        {
            return string.Join("", text.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }

    }
}

