import { createContext, useState } from "react";

const TaskContext = createContext({
  list: [],
  status: "",
  updateList: (tasks) => {},
  updateStatus: (status) => {},
  addTask: (task) => {},
  updateTask: (task) => {},
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

  const updateTask = (task) => {
    let nItems = [...list];
    const index = nItems.findIndex((item) => item.id === task.id);

    if (status === "") {
      nItems[index] = task;
    } else {
      nItems.splice(index, 1);
    }

    setList(nItems);
  };

  const context = {
    list: list,
    status: status,
    updateList: updateList,
    updateStatus: updateStatus,
    addTask: addTask,
    updateTask: updateTask,
  };

  return (
    <TaskContext.Provider value={context}>
      {props.children}
    </TaskContext.Provider>
  );
}

export default TaskContext;
