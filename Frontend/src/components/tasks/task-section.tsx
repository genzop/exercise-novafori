import { useContext } from "react";

import TaskContext from "../../store/task-context";
import TypeTaskSection from "../../types/task-section";

import classes from "./task-section.module.scss";

const TaskSection = (props: TypeTaskSection) => {
  const { value, name, icon } = props;
  const ctx = useContext(TaskContext);

  const onSectionClick = () => {
    ctx.updateStatus(value);
  };

  return (
    <div
      className={`${classes.section} ${
        ctx.status === value ? classes.active : ""
      }`}
      onClick={onSectionClick}
    >
      <div className={classes.icon}>{icon}</div>
      <div className={classes.name}>{name}</div>
    </div>
  );
};

export default TaskSection;
