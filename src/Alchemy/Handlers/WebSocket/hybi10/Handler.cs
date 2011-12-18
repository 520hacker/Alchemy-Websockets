﻿/*
Copyright 2011 Olivine Labs, LLC.
http://www.olivinelabs.com
*/

/*
This file is part of Alchemy Websockets.

Alchemy Websockets is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Alchemy Websockets is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with Alchemy Websockets.  If not, see <http://www.gnu.org/licenses/>.
*/

namespace Alchemy.Handlers.WebSocket.hybi10
{
    /// <summary>
    /// A threadsafe singleton that contains functions which are used to handle incoming connections for the WebSocket Protocol
    /// </summary>
    internal sealed class Handler : WebSocketHandler
    {
        private static Handler _instance;

        private Handler()
        {
            Authentication = new Authentication();
        }

        public new static Handler Instance
        {
            get
            {
                CreateLock.Wait();
                if (_instance == null)
                {
                    _instance = new Handler();
                }
                CreateLock.Release();
                return _instance;
            }
        }
    }
}