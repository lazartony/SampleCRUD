using SampleCRUD.Models;

namespace SampleCRUD.Services
{
    public class SensorDataService
    {
        private static List<SensorData> sensorDataStore= new List<SensorData>();
        private static int idCount = 0;
        public IEnumerable<SensorData> GetAllData()
        {
            return sensorDataStore;
        }
        public SensorData? GetData(int id)
        {
            return sensorDataStore.FirstOrDefault(s => s.Id == id);
        }
        public void AddData(SensorData sensorData)
        {
            sensorData.Id = idCount++;
            sensorDataStore.Add(sensorData);
        }
    }
}
