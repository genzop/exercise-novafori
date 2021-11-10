/* eslint-disable react-hooks/exhaustive-deps */
import { useContext, useEffect } from "react";
import axios from "axios";

import TaskContext from "../../store/task-context";
import TypeTask from "../../types/task";

import TaskItem from "./task-item";

import checked from "./../../assets/images/checked.png";

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
    <div className={classes.list}>
      <div className={classes.title}>To-Do</div>

      {ctx.list.length === 0 && (
        <div className={classes.empty}>
          <img src={checked} alt="Logo" className={classes.icon} />
          <div className={classes.description}>You've done it everything!</div>
        </div>
      )}

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
