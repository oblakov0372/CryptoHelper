import { Outlet } from "react-router-dom"; // Используем только Outlet
import OtcCRMHeader from "../../components/otcCRMHeader/OtcCRMHeader";
import styles from "./OtcCRM.module.scss";

const OtcCRM = () => {
  return (
    <div className={styles.crmContainer}>
      <OtcCRMHeader />
      <Outlet /> {/* Этот Outlet вставляет подстраницы */}
    </div>
  );
};

export default OtcCRM;
