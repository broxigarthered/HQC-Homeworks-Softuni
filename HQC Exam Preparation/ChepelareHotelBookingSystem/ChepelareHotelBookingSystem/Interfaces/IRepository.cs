namespace ChepelareHotelBookingSystem.Interfaces
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        /// <summary>
        /// Gets all items in the repository.
        /// </summary>
        /// <returns>IEnumerable of T</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets an item by its unique ID (in order of addition).
        /// </summary>
        /// <param name="id">The item's unique id.</param>
        /// <returns>Object of type T.</returns>
        T Get(int id);

        /// <summary>
        /// Adds a new item to the repository.
        /// </summary>
        /// <param name="item">Object of type T.</param>
        void Add(T item);

        /// <summary>
        /// Updates an existing item by its unique ID.
        /// </summary>
        /// <param name="id">The item's id.</param>
        /// <param name="newItem">Item of object T.</param>
        /// <returns>Boolean value.</returns>
        bool Update(int id, T newItem);

        /// <summary>
        /// Deletes an item by its unique ID
        /// </summary>
        /// <param name="id">The item's id.</param>
        /// <returns>Boolean value.</returns>
        bool Delete(int id);
    }
}