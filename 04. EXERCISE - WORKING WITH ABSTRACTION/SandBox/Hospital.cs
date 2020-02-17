using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandBox
{
    public class Hospital
    {
        public Hospital()
        {
            Doctors = new List<Doctor>();
            Departments = new List<Department>();
        }
        public List<Doctor> Doctors;

        public List<Department> Departments;
        public void AddDoctor(string firstName,string lastName)
        {
            if (!Doctors.Any(x => x.FirstName == firstName && x.LastName == lastName))
            {
                var doctor = new Doctor(firstName, lastName);
                Doctors.Add(doctor);
            }
        }

        public void AddDepartnent(string name)
        {
            if (!Departments.Any(x => x.Name == name))
            {
                var department = new Department(name);
                Departments.Add(department);
            }
        }

        public void AddPatient(string doctorName, string departmentName, string patientName)
        {
            var doctor = Doctors.FirstOrDefault(x => x.FullName == doctorName);
            var department = Departments.FirstOrDefault(x => x.Name == departmentName);

            var patient = new Patient(patientName);
            doctor.Patients.Add(patient);
            department.AddPatientInRoom(patient);
        }
    }
}
