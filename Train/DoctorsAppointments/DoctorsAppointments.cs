using System.Text;

namespace Train.DoctorsAppointments
{
    internal class DoctorsAppointments
    {
        public void Run(string inputFilePath = "")
        {
            string outputFilePath = $"{inputFilePath}.Test";
            using var input = new StreamReader(inputFilePath);
            using var output = new StreamWriter(outputFilePath);

            //using var input = new StreamReader(Console.OpenStandardInput());
            //using var output = new StreamWriter(Console.OpenStandardOutput());

            int t = int.Parse(input.ReadLine()); //количество наборов входных данных

            for (int i = 0; i < t; i++)
            {
                int[] inputData = Array.ConvertAll(input.ReadLine().Split(), int.Parse);
                int n = inputData[0]; //количество окон приёма у врача
                int m = inputData[1]; //количество записанных пациентов

                int[] w = Array.ConvertAll(input.ReadLine().Split(), int.Parse); // номер окна, на которое записаны пациенты

                (int index, int windowNum)[] appointments = new(int index, int windowNum)[w.Length];
                for (int j = 0; j < m; j++)
                {
                    appointments[j] = (j, w[j]);
                }
                
                // Отсортирвем записи по позрастанию
                Array.Sort(appointments, (a, b) => a.windowNum.CompareTo(b.windowNum));

                // Тут будет храниться новое распределение
                int[] newAppointments = new int[w.Length];
                bool isValid = true;
                string[] response = new string[w.Length];

                for (int j = 0; j < m; j++)
                {
                    var appointment = appointments[j];
                    int index = appointment.index;
                    int windowNum = appointment.windowNum;


                    if (j == 0)
                    {
                        if (windowNum > 1)
                        {
                            //Если есть возможность сдвинуть первое окно на -1, то сдвигаем сразу потому что можем что бы освободить окна для других элементов
                            newAppointments[index] = windowNum - 1;
                            response[index] = "-";
                        }
                        else
                        {
                            newAppointments[index] = windowNum;
                            response[index] = "0";
                        }
                    }        
                    else
                    {
                        var previousAppointment = appointments[j - 1];
                        int previousIndex = previousAppointment.index;
                        int previousWindowNum = newAppointments[previousIndex] > 0 ? newAppointments[previousIndex] : previousAppointment.windowNum; 
         
                        int diff = windowNum - previousWindowNum;
                        if (diff < 0)
                        { 
                            // Данные не валидные, нет возможности распределить пациентов корректно.
                            isValid = false;
                            break;
                        }
                        else if (diff == 0)
                        {
                            //Пересечение, нучно пытаться сделать + 1. Главное не выйти за пределы 
                            int nextWindowNum = windowNum + 1;
                            if (nextWindowNum > n)
                            {
                                isValid = false;
                                break;
                            }
                            else
                            {
                                newAppointments[index] = nextWindowNum;
                                response[index] = "+";
                            }
                        }
                        else if (diff > 1)
                        {
                            //Есть свободные окошки ниже, делаем -1 
                            newAppointments[index] = windowNum - 1;
                            response[index] = "-";
                        }
                        else
                        {
                            // Оставляем все так как есть
                            newAppointments[index] = windowNum;
                            response[index] = "0";
                        }
                    }
                }

                string result = isValid ? string.Join("", response) : "x";
                output.WriteLine(result);
            }
        }
    }
}
