import { useContext } from "react";
import { Checkbox } from "antd";
import axios from "axios";

import TaskContext from "../../store/task-context";

import TypeTask from "../../types/task";

import classes from "./task-item.module.scss";

const TaskItem = (props: TypeTask) => {
  const { id, description, status } = props;

  const ctx = useContext(TaskContext);

  const onCheckboxClick = async () => {
    const response = await axios.put(
      `${process.env.REACT_APP_API_URL}/tasks?id=${id}`
    );

    ctx.updateTask(response.data);
  };

  return (
    <div className={classes.task}>
      <Checkbox checked={status === 1} onChange={onCheckboxClick} />
      <div className={classes.description}>{description}</div>
    </div>
  );
};

export default TaskItem;
