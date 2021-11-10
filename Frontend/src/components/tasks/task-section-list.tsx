import { FiCheckSquare, FiInbox, FiMail } from "react-icons/fi";

import TypeTaskSection from "../../types/task-section";

import TaskSection from "./task-section";

import classes from "./task-section-list.module.scss";

const TaskSectionList = () => {
  const sections = [
    { value: "", name: "All Tasks", icon: <FiMail /> },
    { value: "0", name: "Pending", icon: <FiInbox /> },
    { value: "1", name: "Completed", icon: <FiCheckSquare /> },
  ];

  return (
    <div className={classes.list}>
      <div className={classes.title}>Sections</div>

      {sections.map((item: TypeTaskSection, index) => (
        <TaskSection
          key={index}
          value={item.value}
          name={item.name}
          icon={item.icon}
        />
      ))}
    </div>
  );
};

export default TaskSectionList;
