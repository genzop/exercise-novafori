import TypeTask from "../../types/task";

import classes from "./task-item.module.scss";

const TaskItem = (props: TypeTask) => {
  const { description } = props;

  return (
    <div className={classes.task}>
      <div className={classes.description}>{description}</div>
    </div>
  );
};

export default TaskItem;
