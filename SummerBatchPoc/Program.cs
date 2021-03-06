﻿using System;
using System.Collections.Generic;
using Summer.Batch.Core;
using Summer.Batch.Core.Unity.Xml;
using SummerBatchPoc.Batch;

namespace SummerBatchPoc
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("stuffz");
            JobExecution jobExecution = JobStarter.Start(GetJob(), new MyFirstBatchUnityLoader());
//            JobExecution jobExecution = JobStarter.Start("Batch/MyFirstBatch.xml", new MyFirstBatchUnityLoader());
            Console.WriteLine("end stuffz");
        }

        private static XmlJob GetJob()
        {
            return new XmlJob
            {
                Id = "FLAT_FILE_READER_DB_WRITER",
                JobElements = new List<XmlJobElement>
                {
                    new XmlStep
                    {
                        Chunk = new XmlChunk
                        {
                            Reader = new XmlItemReader{ Ref = "FlatFileReader/FlatFileReader" },
                            Processor = new XmlItemProcessor{Ref = "FlatFileReader/Processor"},
                            Writer = new XmlItemWriter{Ref = "FlatFileReader/DatabaseWriter"},
                            ItemCount = "1000"
                        },
                        Id = "FlatFileReader",
                        Transitions = new List<XmlTransitionElement>()
                    }
                }
            };
        }
    }
}