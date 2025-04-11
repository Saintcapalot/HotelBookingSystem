using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services
{
    public class MealService
    {
        private readonly List<Meal> meals = new();
        private int nextId = 1;

        public Meal Create(Meal meal)
        {
            meal.MealId = nextId++;
            meals.Add(meal);
            return meal;
        }

        public List<Meal> GetAll() => meals;

        public Meal? GetById(int id) =>
            meals.FirstOrDefault(m => m.MealId == id);

        public bool Update(int id, Meal updated)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.MealName = updated.MealName;
            existing.ClientId = updated.ClientId;
            existing.RoomId = updated.RoomId;
            existing.ExpectedAttendees = updated.ExpectedAttendees;
            existing.MealDate = updated.MealDate;
            existing.StartTime = updated.StartTime;
            existing.EndTime = updated.EndTime;
            existing.DietaryNotes = updated.DietaryNotes;
            return true;
        }

        public bool Delete(int id)
        {
            var meal = GetById(id);
            if (meal == null) return false;

            meals.Remove(meal);
            return true;
        }
    }
}