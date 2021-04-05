using AirportSimulatorBackend.Models;
using AirportSimulatorBackend.Repository;
using System;
using System.Collections.Generic;

namespace AirportSimulatorBackend.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepo;
        private readonly IFlightRepository _flightRepo;
        private readonly IRunwayRepository _runwayRepo;
        public RequestService(IRequestRepository requestRepository, IFlightRepository flightRepository, IRunwayRepository runwayRepository)
        {
            _requestRepo = requestRepository;
            _flightRepo = flightRepository;
            _runwayRepo = runwayRepository;
        }

        public void CreateRequest(Request request)
        {
            if (_requestRepo.GetById(request.Flight.FlightCode) != null)
            {
                _requestRepo.CreateRequest(request);
            }
            else
            {
                _flightRepo.CreateFlight(request.Flight);
                _requestRepo.CreateRequest(request);
            }
            //_requestRepo.CreateRequest(request);
        }

        public IEnumerable<Request> GeAllActiveRequests()
        {
            return _requestRepo.GetAllActiveRequests();
        }

        public IEnumerable<Request> GetAllRequests()
        {
            return _requestRepo.GetAllRequests();
        }

        public Request GetRequestById(string fCode)
        {
            return _requestRepo.GetById(fCode);
        }

        //Returns 1 if request was aproved
        //Returns 2 if request is landing or departure and the runway is not available;
        //Returns 3 if request is scheduling and there are already flights scheduled for that time (The tiem buffer between schedules is 3 minutes)
        //Returns 10 for unknow problem
        public int AproveRequest(Request request)
        {
            Runway runway = _runwayRepo.getRunwayInfo();

            if (request.Type == "Landing Request")
            {
                if (!runway.Available)
                {
                    //Runway unavailable
                    return 2;
                }
                else
                {
                    //Runway becomes unavailable when plane is landing
                    _runwayRepo.LockRunway(request.Flight.FlightCode);

                    //This updates the flight status to Landing
                    Flight updatedFlight = _flightRepo.getFlightByFlightCode(request.Flight.FlightCode);
                    updatedFlight.Status = "Landing";
                    _flightRepo.UpdateFlightInfo(updatedFlight);

                    //This updates the previously created landing request and stops being active but becomes aproved
                    //request.active = false;
                    //request.aproved = true;
                    _requestRepo.UpdateRequestAproval(request.Id);

                    //Creates a new request for the ATC for audit purposes
                    Flight atc = _flightRepo.getATCFlightEntity();
                    Request newFlightRequest = new Request();
                    newFlightRequest.Flight = atc;
                    newFlightRequest.Type = "Landing Aproved for Flight " + request.Flight.FlightCode;
                    newFlightRequest.Time = request.Time;
                    newFlightRequest.aproved = true;
                    newFlightRequest.Created = DateTime.Now;
                    newFlightRequest.active = false;
                    _requestRepo.CreateRequest(newFlightRequest);

                    //Success
                    return 1;
                }
            }
            else if (request.Type == "Departure Request")
            {
                if (!runway.Available)
                {
                    //Runway unavailable
                    return 2;
                }
                else
                {
                    //Runway becomes unavailable when plane is landing
                    _runwayRepo.LockRunway(request.Flight.FlightCode);

                    //This updates the flight status to Departing
                    Flight updatedFlight = _flightRepo.getFlightByFlightCode(request.Flight.FlightCode);
                    updatedFlight.Status = "Departing";
                    _flightRepo.UpdateFlightInfo(updatedFlight);

                    //This updates the previously created departure request and stops being active but becomes aproved
                    request.active = false;
                    request.aproved = true;
                    _requestRepo.UpdateRequestAproval(request.Id);

                    //Creates a new request for the ATC for audit purposes
                    Flight atc = _flightRepo.getATCFlightEntity();
                    Request newFlightRequest = new Request();
                    newFlightRequest.Flight = atc;
                    newFlightRequest.Type = "Departure Aproved for Flight " + request.Flight.FlightCode;
                    newFlightRequest.Time = request.Time;
                    newFlightRequest.aproved = true;
                    newFlightRequest.Created = DateTime.Now;
                    newFlightRequest.active = false;
                    _requestRepo.CreateRequest(newFlightRequest);

                    return 1;
                }

            }
            else
            {
                if (request.Type == "Landing Schedule Request")
                {

                    DateTime time1 = request.Time.AddMinutes(-3);
                    DateTime time2 = request.Time.AddMinutes(3);

                    if (_requestRepo.GetRequestsBetweenTimes(time1, time2).Count == 0)
                    {
                        //This updates the flight status to Scheduled to Land
                        Flight updatedFlight = _flightRepo.getFlightByFlightCode(request.Flight.FlightCode);
                        updatedFlight.Status = "Scheduled to Land";
                        _flightRepo.UpdateFlightInfo(updatedFlight);

                        //This updates the previously created landing schedule request and stops being active but becomes aproved
                        //request.active = false;
                        //request.aproved = true;
                        _requestRepo.UpdateRequestAproval(request.Id);

                        //Creates a new request for the ATC for audit purposes
                        Flight atc = _flightRepo.getATCFlightEntity();
                        Request newFlightRequest = new Request();
                        newFlightRequest.Flight = atc;
                        newFlightRequest.Type = "Landing Schedule Aproved for Flight " + request.Flight.FlightCode;
                        newFlightRequest.Time = request.Time;
                        newFlightRequest.aproved = true;
                        newFlightRequest.Created = DateTime.Now;
                        newFlightRequest.active = false;
                        _requestRepo.CreateRequest(newFlightRequest);
                        return 1;
                    }
                    else
                    {
                        return 3;
                    }

                }
                else if (request.Type == "Departure Schedule Request")
                {
                    DateTime time1 = request.Time.AddMinutes(-3);
                    DateTime time2 = request.Time.AddMinutes(3);

                    if (_requestRepo.GetRequestsBetweenTimes(time1, time2).Count == 0)
                    {
                        //This updates the flight status to Scheduled to Departure
                        Flight updatedFlight = _flightRepo.getFlightByFlightCode(request.Flight.FlightCode);
                        updatedFlight.Status = "Scheduled to Departure";
                        _flightRepo.UpdateFlightInfo(updatedFlight);

                        //This updates the previously created departure schedule request and stops being active but becomes aproved
                        request.active = false;
                        request.aproved = true;
                        _requestRepo.UpdateRequestAproval(request.Id);

                        //Creates a new request for the ATC for audit purposes
                        Flight atc = _flightRepo.getATCFlightEntity();
                        Request newFlightRequest = new Request();
                        newFlightRequest.Flight = atc;
                        newFlightRequest.Type = "Departure Schedule Aproved for Flight " + request.Flight.FlightCode;
                        newFlightRequest.Time = request.Time;
                        newFlightRequest.aproved = true;
                        newFlightRequest.Created = DateTime.Now;
                        newFlightRequest.active = false;
                        _requestRepo.CreateRequest(newFlightRequest);
                        return 1;
                    }
                    else
                    {
                        return 3;
                    }

                }

            }
            return 10;
        }

        public void DenyRequest(Request request)
        {

            Flight updatedFlight = _flightRepo.getFlightByFlightCode(request.Flight.FlightCode);
            updatedFlight.Status = "Request Denied";

            _requestRepo.UpdateRequestDenial(request.Id);

            Flight atc = _flightRepo.getATCFlightEntity();
            Request newFlightRequest = new Request();
            newFlightRequest.Flight = atc;
            newFlightRequest.Type = "Request Denied for " + request.Flight.FlightCode;
            newFlightRequest.Time = request.Time;
            newFlightRequest.aproved = true;
            newFlightRequest.Created = DateTime.Now;
            newFlightRequest.active = false;
            _requestRepo.CreateRequest(newFlightRequest);

        }
    }
}