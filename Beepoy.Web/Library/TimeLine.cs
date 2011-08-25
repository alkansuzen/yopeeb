using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beepoy.Web.Models;

namespace Beepoy.Web.Library
{
    public  class TimeLine 
    {
        private List<Markline> markLines;

        private TimeLine()
        {
            this.markLines = new List<Markline>();
        }

        public List<Markline> MarkLines { get { return this.markLines; } }

        public void addMarkLine(Markline mLine)
        {
            this.markLines.Add(mLine);
        }




        public static TimeLine Create(List<Beep> beeps)
        {

            Beep anterior;
            Beep atual;
            Beep proximo;
            int value;
            DateTime tempDate;
            List<DateTime> timelineMarks = new List<DateTime>();

            TimeLine timeline = new TimeLine();
            DateTime newDate;
            for (int i = 0; i < beeps.Count; i++)
            {
                atual = beeps[i];

                if ((i + 1) < beeps.Count)
                {
                    proximo = beeps[i + 1];
                }
                else
                    proximo = atual;

                if (i == 0)
                {
                    anterior = atual;
                }
                else
                    anterior = beeps[i - 1];

                bool second = false;


                TimeSpan difference = proximo.DateInsert.Subtract(atual.DateInsert);

                /****
                 * Adiciona uma linha de marcação e o primeiro Beep
                 * 
                 * Verifica se o próximo beep está foi enviado no mesmo dia que o primeiro
                 * 
                 * Caso positivo será inserido na mesma marcação da timeline, senão uma
                 * 
                 * nova marcação será colocada para o mesmo
                 * 
                ****/
               



                if (i % 2 == 0)
                {
                    if (i == 0)
                    {

                        timeline.addMarkLine(new Markline(atual, atual.DateInsert));


                        if (difference.Days > 0)
                        {

                            timeline.MarkLines.Last().Line =
                                   new DateTime(timeline.MarkLines.Last().Line.Year,
                                                timeline.MarkLines.Last().Line.Month,
                                                timeline.MarkLines.Last().Line.Day);

                            timeline.addMarkLine(new Markline(proximo, proximo.DateInsert)); //adiciona beep
                        }
                        else
                        {
                            timeline.MarkLines.Last().Beeps.Add(proximo); //adiciona beep

                        }

                    }
                    else
                    {
                        /**
                         * Segunda etapa:
                         * 
                         * Faz a diferença do beep atual e da data da ultima linha de marcação
                         * 
                         * 
                         * 
                         * 
                        **/

                        TimeSpan secondDifference = atual.DateInsert.Subtract(timeline.MarkLines.Last().Beeps.Last().DateInsert);

                        if (timeline.MarkLines.Last().Beeps.Count == 1 &&
                                         secondDifference.Days == 0 &&
                                         atual.DateInsert.Day == timeline.MarkLines.Last().Beeps.Last().DateInsert.Day)
                        {
                            timeline.MarkLines.Last().Beeps.Add(atual); //adiciona beep a timeline
                            secondDifference = anterior.DateInsert.Subtract(timeline.MarkLines[timeline.MarkLines.Count - 2].Beeps.Last().DateInsert);
                            atual = proximo;
                            second = true;

                            difference = timeline.MarkLines.Last().Beeps.First().DateInsert.Subtract(timeline.MarkLines[timeline.MarkLines.Count - 2].Beeps.First().DateInsert);
                        }




                        if (difference.Days == 0)
                        {

                            if (secondDifference.Days > 0)
                            {

                                if (second)
                                {
                                    timeline.MarkLines.Last().Line = new DateTime(timeline.MarkLines.Last().Beeps.First().DateInsert.Year,
                                                        timeline.MarkLines.Last().Beeps.First().DateInsert.Month,
                                                        timeline.MarkLines.Last().Beeps.First().DateInsert.Day);

                                }

                            }
                            else if (secondDifference.Hours > 0)
                            {
                                int hours = secondDifference.Hours;

                                int firstHour = timeline.MarkLines.Last().Beeps.First().DateInsert.Hour;

                                int lastElemHour;

                                tempDate = timeline.MarkLines[timeline.MarkLines.Count - 1].Beeps.Last().DateInsert;

                                if (timeline.MarkLines.Count > 2)
                                {
                                    tempDate = timeline.MarkLines[timeline.MarkLines.Count - 2].Beeps.Last().DateInsert;

                                    lastElemHour = timeline.MarkLines[timeline.MarkLines.Count - 2].Beeps.Last().DateInsert.Second;
                                }
                                else
                                {
                                    lastElemHour = firstHour;
                                }

                                value = firstHour - (firstHour % 4);

                                newDate =
                                       new DateTime(timeline.MarkLines.Last().Beeps.First().DateInsert.Year,
                                                   timeline.MarkLines.Last().Beeps.First().DateInsert.Month,
                                                   timeline.MarkLines.Last().Beeps.First().DateInsert.Day,
                                                  value, 0, 0);

                                if (hours > 4 && newDate > tempDate)
                                {
                                    timeline.MarkLines.Last().Line = newDate;
                                }
                                else
                                {
                                    timeline.MarkLines.Last().Line =
                                        new DateTime(timeline.MarkLines.Last().Beeps.First().DateInsert.Year,
                                                    timeline.MarkLines.Last().Beeps.First().DateInsert.Month,
                                                    timeline.MarkLines.Last().Beeps.First().DateInsert.Day,
                                                    firstHour, 0, 0);
                                }
                            }
                            else if (secondDifference.Minutes > 0)
                            {
                                int minutes = secondDifference.Minutes;

                                int firstMin = timeline.MarkLines.Last().Beeps.First().DateInsert.Minute;

                                int lastElemMin;

                                tempDate = timeline.MarkLines.Last().Beeps.Last().DateInsert;

                                if (timeline.MarkLines.Count > 2)
                                {
                                    tempDate = timeline.MarkLines[timeline.MarkLines.Count - 2].Beeps.Last().DateInsert;
                                    lastElemMin = tempDate.Second;
                                }
                                else
                                {
                                    lastElemMin = firstMin;
                                }

                                value = firstMin - (firstMin % 5);

                                newDate =
                                       new DateTime(timeline.MarkLines.Last().Beeps.First().DateInsert.Year,
                                                   timeline.MarkLines.Last().Beeps.First().DateInsert.Month,
                                                   timeline.MarkLines.Last().Beeps.First().DateInsert.Day,
                                                   timeline.MarkLines.Last().Beeps.First().DateInsert.Hour,
                                                   value, 0);

                                if (minutes > 5 && newDate > tempDate)
                                {
                                    timeline.MarkLines.Last().Line = newDate;
                                }
                                else
                                {
                                    timeline.MarkLines.Last().Line =
                                        new DateTime(timeline.MarkLines.Last().Beeps.First().DateInsert.Year,
                                                    timeline.MarkLines.Last().Beeps.First().DateInsert.Month,
                                                    timeline.MarkLines.Last().Beeps.First().DateInsert.Day,
                                                    timeline.MarkLines.Last().Beeps.First().DateInsert.Hour,
                                                    firstMin, 0);
                                }
                            }
                            else
                            {
                                int seconds = secondDifference.Seconds;

                                int firstSec = timeline.MarkLines.Last().Beeps.First().DateInsert.Second;

                                int lastElemSec;

                                tempDate = timeline.MarkLines.Last().Beeps.Last().DateInsert;

                                if (timeline.MarkLines.Count > 2)
                                {
                                    tempDate = timeline.MarkLines[timeline.MarkLines.Count - 2].Beeps.Last().DateInsert;

                                    lastElemSec = tempDate.Second;
                                }
                                else
                                {
                                    lastElemSec = firstSec;
                                }

                                value = firstSec - (firstSec % 5);

                                newDate =
                                       new DateTime(timeline.MarkLines.Last().Beeps.First().DateInsert.Year,
                                                   timeline.MarkLines.Last().Beeps.First().DateInsert.Month,
                                                   timeline.MarkLines.Last().Beeps.First().DateInsert.Day,
                                                   timeline.MarkLines.Last().Beeps.First().DateInsert.Hour,
                                                   timeline.MarkLines.Last().Beeps.First().DateInsert.Minute,
                                                   value);

                                if (firstSec > 5 && newDate > tempDate)
                                {
                                    timeline.MarkLines.Last().Line = newDate;
                                }
                                else
                                {
                                    timeline.MarkLines.Last().Line =
                                        new DateTime(timeline.MarkLines.Last().Beeps.First().DateInsert.Year,
                                                    timeline.MarkLines.Last().Beeps.First().DateInsert.Month,
                                                   timeline.MarkLines.Last().Beeps.First().DateInsert.Day,
                                                    timeline.MarkLines.Last().Beeps.First().DateInsert.Hour,
                                                    timeline.MarkLines.Last().Beeps.First().DateInsert.Minute,
                                                    firstSec);
                                }
                            }
                        }
                        else if (difference.Days < 30)
                        {
                            int days = secondDifference.Days;

                            int firstDay = timeline.MarkLines.Last().Beeps.First().DateInsert.Day;
                            int lastElemDay;

                            tempDate = timeline.MarkLines.Last().Beeps.First().DateInsert;

                            if (timeline.MarkLines.Count > 2)
                            {
                                tempDate = timeline.MarkLines[timeline.MarkLines.Count - 2].Beeps.Last().DateInsert;

                                lastElemDay = tempDate.Day;
                            }
                            else
                            {
                                lastElemDay = firstDay;
                            }

                            value = firstDay - (firstDay % 5);

                            value = (value == 0) ? 1 : value;

                            newDate =
                                   new DateTime(timeline.MarkLines.Last().Beeps.Last().DateInsert.Year,
                                               timeline.MarkLines.Last().Beeps.Last().DateInsert.Month,
                                               value);

                            if (firstDay > 5 && newDate > tempDate)
                            {
                                timeline.MarkLines.Last().Line = newDate;
                            }
                            else
                            {
                                timeline.MarkLines.Last().Line =
                                    new DateTime(timeline.MarkLines.Last().Beeps.First().DateInsert.Year,
                                                timeline.MarkLines.Last().Beeps.First().DateInsert.Month,
                                                firstDay);
                            }
                        }
                        else if (difference.Days > 365)
                        {
                            int days = secondDifference.Days;

                            int firstMonth = timeline.MarkLines.Last().Beeps.First().DateInsert.Month;

                            timeline.MarkLines.Last().Line =
                                new DateTime(timeline.MarkLines.Last().Line.Year,
                                             firstMonth, 0);
                        }
                        timeline.addMarkLine(new Markline(atual, atual.DateInsert));
                    }
                }
            }

            return timeline;

        }


 
    }


    public class Markline{

        public Markline(){
            this.beeps = new List<Beep>();
        }

        public Markline(Beep beep, DateTime line):this()
        {
            this.addBeep(beep);
            Line = line;
        }

        private List<Beep> beeps;

        public DateTime Line { get; set; }

        public List<Beep> Beeps { get { return this.beeps;  } }

        public void addBeep( Beep beep){

            if (this.beeps.Count == 2)
            {
                throw new Exception("Markline is full");
            }
            else
            {
                this.beeps.Add(beep);
            }
        }

    }
}
