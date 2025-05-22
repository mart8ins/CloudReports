import { useEffect, useState } from 'react';
import axios from 'axios';
import { format, parseISO } from 'date-fns';
import WeatherChart from "./WeatherChart";
import HourSelect from "./HourSelect";
import ReportCalendar from "./ReportCalendar";
import Loading from "../Loading";
import "./WeatherReports.css"

function WeatherReports() {
    const [reports, setReports] = useState([]);
    const [reportMeta, setReportMeta] = useState("");
    const [lastHourDataFor, setLastHourDataFor] = useState("");
    const [selectedDate, setSelectedDate] = useState("");

    useEffect(() => {
        fetchReports("api/weatherreports/reports");
        setLastHourDataFor("");
    }, []);

    useEffect(() => {
        const dateTimeFormat = "MMMM dd, yyyy HH:mm:ss";
        const dateFormat = "MMMM dd, yyyy";
        const timeFormat = "HH:mm:ss";

        if (reports[0]?.lastUpdateTime != null && reports[0]?.createdAt != null) {
            if (lastHourDataFor.length > 0)
            {
                setReportMeta(`Temperature avarages for last ${lastHourDataFor} hour(s). Last fetch at ${format(reports[0].createdAt, timeFormat)}, actual data from ${format(parseISO(reports[0].lastUpdateTime), timeFormat)}`);
            }
            else if (selectedDate.length > 0)
            {
                setReportMeta(`Temperature avarages for ${format(selectedDate, dateFormat) }`);
            }
            else
            {
                setReportMeta(`Temperature last update time (${format(parseISO(reports[0].lastUpdateTime), dateTimeFormat)})`);
            }
        };
    }, [reports]);

    const handleHourChange = (e) => {
        setSelectedDate("");
        setLastHourDataFor(e.target.value);
        fetchReports(`api/weatherreports/reports?lastHours=${e.target.value}`);
    };

    const dateChanged = (date) => {
        setLastHourDataFor("");
        setSelectedDate(date);
        fetchReports(`api/weatherreports/reports?date=${date}`);
    }

    return (
        <div className="weather_report">
            {reports.length > 0 ?
                <div>
                    <h3>{reportMeta}</h3>
                    <WeatherChart data={reports} avarages={lastHourDataFor.length > 0 || selectedDate.length > 0} />
                </div> :
                <Loading message={"No data to show"} />}
            <div className="report_filter_container">
                <HourSelect handleHourChange={handleHourChange} lastHourDataFor={lastHourDataFor} />
                <ReportCalendar dateChanged={dateChanged} />
            </div>
      </div>
    );

    async function fetchReports(fetchUrl) {
        const response = await axios.get(fetchUrl);
        setReports(response.data);
    }
}

export default WeatherReports;