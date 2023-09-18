import { useEffect, useState } from "react";
import { anonymRequest } from "../../../utils/Request";
import CrmMessagesTable from "../../../components/crmMessagesTable/CrmMessagesTable";
import LoadingSpinner from "../../../components/loadingSpinner/LoadingSpinner";
import Pagination from "../../../components/pagination/Pagination";
import { QueryParamsType } from "../../../types/requesTypes/QueryParamsType";

const OtcCRMMessages = () => {
  const [telegramMessages, setTelegramMessages] = useState<
    TelegramMessageType[]
  >([]);
  const [countPages, setCountPages] = useState<number>(0);
  const [currentPage, setCurrentPage] = useState<number>(1);
  const [isLoading, setIsLoading] = useState<Boolean>(true);
  const [messageType, setMessageType] = useState<string>("all");
  const [searchQuery, setSearchQuery] = useState<string>("");
  const [pageSize, setPageSize] = useState<number>(20);
  const [searchTimeout, setSearchTimeout] = useState<NodeJS.Timeout | null>(
    null
  );

  const fetchData = async () => {
    try {
      const queryParams: QueryParamsType = {
        pageNumber: currentPage,
        pageSize: pageSize,
        messageType: messageType,
      };

      if (searchQuery.trim() !== "") {
        queryParams.searchQuery = searchQuery;
      }

      const response = await anonymRequest("CRMTelegramMessages", {
        queryParams,
      });
      setTelegramMessages(response.data.telegramMessages);
      setCountPages(response.data.countPages);
      setIsLoading(false);
    } catch (error) {
      console.error("Ошибка при получении данных:", error);
      setIsLoading(false);
    }
  };

  useEffect(() => {
    setIsLoading(true);
    fetchData();
  }, [messageType, currentPage, pageSize]);

  const handleSearchQueryChange = (query: string) => {
    setSearchQuery(query);
    setCurrentPage(1);

    if (searchTimeout) {
      clearTimeout(searchTimeout);
    }

    const newSearchTimeout = setTimeout(() => {
      fetchData();
    }, 700);

    setSearchTimeout(newSearchTimeout);
  };

  const handleMessageTypeChange = (type: any) => {
    setMessageType(type);
    setCurrentPage(1);
  };

  const handlePageSize = (size: number) => {
    setPageSize(size);
    setCurrentPage(1);
  };

  return (
    <>
      {isLoading ? (
        <span className="block mt-10">
          <LoadingSpinner />
        </span>
      ) : (
        <>
          <div className="flex justify-between items-center bg-black px-7">
            <input
              className="bg-gray-600 px-3 py-1 rounded-sm"
              type="text"
              placeholder="Search..."
              value={searchQuery}
              onChange={(e) => handleSearchQueryChange(e.target.value)}
            />
            <div className="bg-black block text-center py-4">
              <label className="mr-2">ALL/WTS/WTB</label>
              <select
                className="bg-gray-600  px-4 py-1 rounded-sm"
                value={messageType}
                onChange={(e) => handleMessageTypeChange(e.target.value)}
              >
                <option value="all">All</option>
                <option value="wts">WTS</option>
                <option value="wtb">WTB</option>
              </select>
            </div>
          </div>
          <CrmMessagesTable telegramMessages={telegramMessages} />
          <div className="flex justify-between items-center">
            {countPages > 1 && (
              <Pagination
                countPages={countPages}
                onChangePage={setCurrentPage}
              />
            )}
            <select
              className="bg-gray-600  px-4 py-1 rounded-sm "
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

export default OtcCRMMessages;
