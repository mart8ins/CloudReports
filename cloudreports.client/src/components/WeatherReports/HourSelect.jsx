function HourSelect({ handleHourChange, lastHourDataFor }) {

  return (
      <div>
          <label htmlFor="hoursSelect">Avarage temp. for todays: </label>
          <select id="hoursSelect" value={lastHourDataFor} onChange={handleHourChange}>
              <option value="">-- Select --</option>
              <option value="1">Last 1 hour</option>
              <option value="3">Last 3 hours</option>
              <option value="5">Last 5 hours</option>
              <option value="8">Last 8 hours</option>
              <option value="12">Last 12 hours</option>
          </select>
      </div>
  );
}

export default HourSelect;