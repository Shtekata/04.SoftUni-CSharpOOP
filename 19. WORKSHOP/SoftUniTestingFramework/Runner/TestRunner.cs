﻿namespace SoftUniTestingFramework.Runner
{
    using SoftUniTestingFramework.Attributes;
    using SoftUniTestingFramework.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    public class TestRunner
    {
        public List<string> Run(string path)
        {
            var listOfResults = new List<string>();
            //fetch all class with attribute TestClass
            var testClasses = Assembly
                .LoadFile(path)
                .GetTypes()
                .Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(TestClassAttribute)))
                .ToList();
        
            foreach (var classType in testClasses)
            {
                var testMethods = classType
                    .GetMethods()
                    .Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(TestMethodAttribute)))
                    .ToList();

                var classInstance = Activator.CreateInstance(classType);


                foreach (var testMethod in testMethods)
                {
                    try
                    {
                        testMethod.Invoke(classInstance, new object[] { });

                        listOfResults.Add($"{testMethod.Name} passed successufully!");
                    }
                    catch (TargetInvocationException ex)
                    {
                        listOfResults.Add($"{testMethod.Name} failed! - {ex.InnerException.Message}");
                    }
                    //Create instance of a class
                    //Invoke method
                    //Try catch
                }
            }
            return listOfResults;
        }
    }
}
