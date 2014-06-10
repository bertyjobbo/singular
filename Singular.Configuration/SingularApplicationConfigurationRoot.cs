using System;

namespace Singular.Configuration
{
    public class SingularApplicationConfigurationRoot
    {
        /// <summary>
        /// Is master
        /// </summary>
        public SingularApplicationConfigurationRoot IsMasterApplication()
        {
            Application.IsMasterApplication = true;
            return this;
        }

        /// <summary>
        /// Application
        /// </summary>
        public SingularApplicationBase Application { get; set; }

        /// <summary>
        /// Has name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SingularApplicationConfigurationRoot Named(string name)
        {
            if (!Application.IsMasterApplication) throw new Exception("Cannot name non-master application");

            Application.Name = name;

            return this;
        }

        public SingularApplicationConfigurationRoot WithAdminSection(Action<SingularAdminSection> action)
        {
            var section = new SingularAdminSection();
            action.Invoke(section);
            Application.AdminSections.Add(section);
            return this;
        }
    }
}