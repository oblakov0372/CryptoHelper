import { useEffect, useState } from "react";
import LoadingSpinner from "../../../components/loadingSpinner/LoadingSpinner";
import Pagination from "../../../components/pagination/Pagination";
import { QueryParamsType } from "../../../types/requesTypes/QueryParamsType";
import { anonymRequest } from "../../../utils/Request";
import { TelegramAccountLite } from "../../../types/TelegramAccountLite";
import CrmAccountingTable from "../../../components/crmAccountingTable/CrmAccountingTable";

const OtcCrmAccounting = () => {
  const [telegramsAccounts, setTelegramAccounts] = useState<
    TelegramAccountLite[]
  >([]);
  const [countPages, setCountPages] = useState<number>(0);
  const [currentPage, setCurrentPage] = useState<number>(1);
  const [pageSize, setPageSize] = useState<number>(25);
  const [isLoading, setIsLoading] = useState<Boolean>(false);
  const [searchQuery, setSearchQuery] = useState<string>("");
  const [searchTimeout, setSearchTimeout] = useState<NodeJS.Timeout | null>(
    null
  );

  const fetchData = async () => {
    try {
      const queryParams: QueryParamsType = {
        pageNumber: currentPage,
        pageSize: pageSize,
      };

      if (searchQuery.trim() !== "") {
        queryParams.searchQuery = searchQuery;
      }

      const response = await anonymRequest("TelegramUsers", {
        queryParams,
      });
      setTelegramAccounts(response.data.telegramUsers);
      setCountPages(response.data.countPages);
      setIsLoading(false);
    } catch (error) {
      console.error("Ошибка при получении данных:", error);
      setIsLoading(false);
    }
  };

  useEffect(() => {
    if (searchTimeout) {
      clearTimeout(searchTimeout);
    }

    const newSearchTimeout = setTimeout(() => {
      fetchData();
    }, 700);

    setSearchTimeout(newSearchTimeout);
  }, [searchQuery]);

  const handlePageSize = (size: number) => {
    setPageSize(size);
    setCurrentPage(1);
  };

  useEffect(() => {
    setIsLoading(true);
    fetchData();
  }, [pageSize, currentPage]);
  return (
    <>
      {isLoading ? (
        <span className="block mt-10">
          <LoadingSpinner />
        </span>
      ) : (
        <>
          <div className="flex justify-between items-center bg-black px-7 py-2">
            <input
              className="bg-gray-600 px-3 py-1 rounded-sm"
              type="text"
              placeholder="Search..."
              value={searchQuery}
              onChange={(e) => setSearchQuery(e.target.value)}
            />
          </div>
          <CrmAccountingTable telegramAccounting={telegramsAccounts} />
          <div className="flex justify-between items-center">
            {countPages > 1 && (
              <Pagination
                currentPage={currentPage - 1}
                countPages={countPages}
                onChangePage={setCurrentPage}
              />
            )}
            <select
              className="bg-gray-600  px-4 py-1 rounded-sm ml-7"
              value={pageSize}
              onChange={(e) => handlePageSize(parseInt(e.target.value))}
            >
              <option value="10">10</option>
              <option value="25">25</option>
              <option value="50">50</option>
              <option value="100">100</option>
            </select>
          </div>
        </>
      )}
    </>
  );
};

export default OtcCrmAccounting;
