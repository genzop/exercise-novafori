import TaskType from "../../types/task";

import classes from "./task-item.module.scss";

const TaskItem = (props: TaskType) => {
  const { description } = props;

  return (
    <div className={classes.task}>
      <div className={classes.description}>{description}</div>
    </div>
  );
};

export default TaskItem;
