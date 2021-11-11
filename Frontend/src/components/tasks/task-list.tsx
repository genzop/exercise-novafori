/* eslint-disable react-hooks/exhaustive-deps */
import { useContext, useEffect, useState } from "react";
import axios from "axios";
import { FiPlus } from "react-icons/fi";

import TaskContext from "../../store/task-context";
import TypeTask from "../../types/task";

import TaskItem from "./task-item";

import checked from "./../../assets/images/checked.png";

import classes from "./task-list.module.scss";
import TaskForm from "./task-form";

const TaskList = () => {
  const ctx = useContext(TaskContext);

  const [formVisible, setFormVisible] = useState(false);

  useEffect(() => {
    async function getList() {
      const response = await axios.get(
        `${process.env.REACT_APP_API_URL}/tasks?status=${ctx.status}`
      );
      ctx.updateList(response.data);
    }

    getList();
  }, [ctx.status]);

  const onAddClick = () => {
    setFormVisible(true);
  };

  const onAddClose = () => {
    setFormVisible(false);
  };

  return (
    <div className={classes.list}>
      <div className={classes.title}>To Do</div>

      {ctx.list.length === 0 && (
        <div className={classes.empty}>
          <img src={checked} alt="Logo" className={classes.icon} />
          <div className={classes.description}>You're all done!</div>
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

      <div className={classes.add} onClick={onAddClick}>
        <FiPlus />
      </div>
      <TaskForm visible={formVisible} onClose={onAddClose} />
    </div>
  );
};

export default TaskList;
