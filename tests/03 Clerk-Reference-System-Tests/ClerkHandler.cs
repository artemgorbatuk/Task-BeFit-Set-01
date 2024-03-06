using _03_Clerk_Reference_System;

namespace _03_Clerk_Reference_System_Tests
{
    public class ClerkHandler
    {
        public void AddRequirement(Clerk clerk, Certificate certificate)
        {
            clerk.Requirements.Add(certificate);
        }

        public void AddIssueCertificate(Clerk clerk, Certificate certificate)
        {
            clerk.IssuedCertificate = certificate;
        }

        public bool CanIssueCertificate(Clerk clerk, List<Certificate> requirements)
        {
            return clerk.Requirements.Count == requirements.Count && clerk.Requirements.All(requirements.Contains);
        }

        public Certificate IssueCertificate(Clerk clerk, List<Certificate> certificates)
        {
            if (CanIssueCertificate(clerk, certificates))
            {
                return clerk.IssuedCertificate;
            }

            throw new Exception("The certificate was refused. Not all requirements are met.");
        }

    }
}
