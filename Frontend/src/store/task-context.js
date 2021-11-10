import { createContext, useState } from "react";

const TaskContext = createContext({
  list: [],
  status: "",
  updateList: (tasks) => {},
  updateStatus: (status) => {},
  addTask: (task) => {},
});

export function TaskContextProvider(props) {
  const [list, setList] = useState([]);
  const [status, setStatus] = useState("");

  const updateList = (tasks) => {
    setList(tasks);
  };

  const updateStatus = (status) => {
    setStatus(status);
  };

  const addTask = (task) => {
    let nItems = [...list];
    nItems.push(task);
    setList(nItems);
  };

  const context = {
    list: list,
    status: status,
    updateList: updateList,
    updateStatus: updateStatus,
    addTask: addTask,
  };

  return (
    <TaskContext.Provider value={context}>
      {props.children}
    </TaskContext.Provider>
  );
}

export default TaskContext;
