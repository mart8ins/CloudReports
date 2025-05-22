import "./LogEntry.css";

function LogEntry({ log }) {
  return (
      <tr className="log_entry" key={log.id}>
          <td className="entry_sm">{log.id}</td>
          <td className="entry_sm">{log.httpMethod}</td>
          <td className="entry_sm">{log.statusCode}</td>
          <td className="entry_sm">{log.isSuccess ? 'Yes' : 'No'}</td>
          <td>{new Date(log.timeStamp).toLocaleString()}</td>
          <td className="entry_lg">{log.requestUrl}</td>
          <td>{log.errorMessage || '-'}</td>
      </tr>
  );
}

export default LogEntry;