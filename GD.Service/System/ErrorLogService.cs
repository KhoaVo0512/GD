using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface IErrorLogService
    {
        Result Create(ErrorLog errorLog);
        Result Save();
    }

    public class ErrorLogService : IErrorLogService
    {
        IErrorLogRepository _errorLogRepository;
        IUnitOfWork _unitOfWork;

        public ErrorLogService(IErrorLogRepository errorLogRepository, IUnitOfWork unitOfWork)
        {
            this._errorLogRepository = errorLogRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Create(ErrorLog errorLog)
        {
            try
            {
                errorLog.CreateDate = DateTime.Now;
                _errorLogRepository.Add(errorLog);
                _unitOfWork.Commit();

                return new Result() { Status = true, ID = 0, Notication = "Thêm thành công" };

            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }

        public Result Save()
        {
            try
            {
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Lưu thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }  
    }
}
