using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface IPuzzleService
    {
        Result Add(Puzzle puzzle);

        Result Update(Puzzle puzzle);

        Result Delete(int id);

        IEnumerable<Puzzle> GetAll();

        IEnumerable<Puzzle> GetAllByActive(bool active);

        Puzzle GetByAnswer(string answer);

        Puzzle GetById(int id);

        Result Save();
    }

    public class PuzzleService : IPuzzleService
    {
        IPuzzleRepository _puzzleRepository;
        IUnitOfWork _unitOfWork;

        public PuzzleService(IPuzzleRepository puzzleRepository, IUnitOfWork unitOfWork)
        {
            this._puzzleRepository = puzzleRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(Puzzle puzzle)
        {
            try
            {
                puzzle.Active = true;
                puzzle.CreateDate = DateTime.Now;
                _puzzleRepository.Add(puzzle);
                _unitOfWork.Commit();
                
                return new Result() { Status = true, ID = puzzle.ID, Notication = "Thêm thành công" };

            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
            
        }

        public Result Delete(int id)
        {
            try
            {
                _puzzleRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public IEnumerable<Puzzle> GetAll()
        {
            return _puzzleRepository.GetAll();
        }

       
        public IEnumerable<Puzzle> GetAllByActive(bool active)
        {
            return _puzzleRepository.GetMulti(x => x.Active == active);
        }

        public Puzzle GetById(int id)
        {
            return _puzzleRepository.GetSingleById(id);
        }

        public Puzzle GetByAnswer(string answer)
        {
            return _puzzleRepository.GetSingleByCondition(x => x.Answer.ToLower().Trim() == answer.ToLower().Trim());
        }

        public Result Save()
        {
            try
            {
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Lưu thành công" };
            }
            catch(Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
            
        }

        public Result Update(Puzzle puzzle)
        {
            try
            {
                puzzle.UpdateDate = DateTime.Now;
                _puzzleRepository.Update(puzzle);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = puzzle.ID, Notication = "Cập nhật thành công" };
            }
            catch(Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }
    }
}
