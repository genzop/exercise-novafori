import { Col, Row } from "antd";

import { TaskContextProvider } from "./store/task-context";

import TaskList from "./components/tasks/task-list";
import TaskSectionList from "./components/tasks/task-section-list";

function App() {
  return (
    <TaskContextProvider>
      <Row>
        <Col xs={{ span: 24, order: 2 }} lg={{ span: 4, order: 1 }}>
          <TaskSectionList />
        </Col>
        <Col xs={{ span: 24, order: 1 }} lg={{ span: 20, order: 2 }}>
          <TaskList />
        </Col>
      </Row>
    </TaskContextProvider>
  );
}

export default App;
