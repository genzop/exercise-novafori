/* eslint-disable react-hooks/exhaustive-deps */
import { useContext, useEffect } from "react";
import axios from "axios";

import TaskContext from "../../store/task-context";
import TypeTask from "../../types/task";

import TaskItem from "./task-item";

import classes from "./task-list.module.scss";

const TaskList = () => {
  const ctx = useContext(TaskContext);

  useEffect(() => {
    async function getList() {
      const response = await axios.get(
        `${process.env.REACT_APP_API_URL}/tasks?status=${ctx.status}`
      );
      ctx.updateList(response.data);
    }

    getList();
  }, [ctx.status]);

  return (
    <div>
      {ctx.list.map((item: TypeTask, index) => (
        <TaskItem
          key={index}
          id={item.id}
          description={item.description}
          status={item.status}
        />
      ))}
    </div>
  );
};

export default TaskList;
