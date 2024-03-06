namespace _03_Clerk_Reference_System
{
    public class ClerkService
    {
        public async Task<List<int>> CertificateAcquisitionOrderAsync(List<Clerk> clerks)
        {
            var order = new List<int>();
            var visited = new HashSet<int>();

            var tasks = new List<Task>();

            foreach (var clerk in clerks)
            {
                var task = VisitClerkAsync(clerks, clerk, order, visited);
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);

            return order;
        }

        private Task VisitClerkAsync(List<Clerk> clerks, Clerk clerk, List<int> order, HashSet<int> visited)
        {
            var tasks = new List<Task>();

            if (!visited.Contains(clerk.IssuedCertificate.Id))
            {
                visited.Add(clerk.IssuedCertificate.Id);

                foreach (var requirement in clerk.Requirements)
                {
                    var requiredClerk = FindClerkByCertificateId(clerks, requirement.Id);
                    if (requiredClerk != null)
                    {
                        var task = VisitClerkAsync(clerks, requiredClerk, order, visited);
                        tasks.Add(task);
                    }
                }

                order.Add(clerk.IssuedCertificate.Id);
            }
            return Task.WhenAll(tasks);
        }

        private Clerk FindClerkByCertificateId(List<Clerk> clerks, int certificateId)
        {
            return clerks.First(c => c.IssuedCertificate.Id == certificateId);
        }
    }
}