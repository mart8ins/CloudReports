import React, { useState, useEffect } from 'react';
import Calendar from 'react-calendar';
import 'react-calendar/dist/Calendar.css';

function ReportCalendar({ dateChanged }) {
    const [date, setDate] = useState(null);

    useEffect(() => {
        if (date != null) {
            dateChanged(date.toLocaleDateString('en-CA'));
        }
    }, [date]);

    return (
        <div>
            Select date to get weather temperature avarages
            <Calendar onChange={setDate} value={date} />
        </div>
    );
}

export default ReportCalendar;