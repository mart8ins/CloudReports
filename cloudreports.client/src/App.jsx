import { useEffect, useState } from 'react';

import './App.css';
import RequestLogs from "./components/RequestLogs/RequestLogs"
import WeatherReports from "./components/WeatherReports/WeatherReports"

function App() {
    const [showLogs, setShowLogs] = useState(false);

    useEffect(() => { }, [])

    const changeDataShow = () => {
        setShowLogs(!showLogs)
    };

    return (
        <div>
            <button className="change_btn" onClick={changeDataShow}>{showLogs ? "Switch to weather report" : "Switch to request logs"}</button>
            {showLogs ? <RequestLogs /> : <WeatherReports />}
        </div>
    );
}

export default App;