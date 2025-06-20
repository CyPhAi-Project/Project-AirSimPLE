// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//in header only mode, control library is not available
#ifndef AIRLIB_HEADER_ONLY
//RPC code requires C++14. If build system like Unreal doesn't support it then use compiled binaries
#ifndef AIRLIB_NO_RPC
//if using Unreal Build system then include precompiled header file first

#include "vehicles/car/api/CarRpcLibServer.hpp"

#include "common/Common.hpp"
STRICT_MODE_OFF

#include "common/common_utils/MinWinDefines.hpp"
#undef NOUSER

#include "common/common_utils/WindowsApisCommonPre.hpp"
#undef FLOAT

#include "rpc/server.h"

#include "common/common_utils/WindowsApisCommonPost.hpp"

#include "vehicles/car/api/CarRpcLibAdaptors.hpp"

STRICT_MODE_ON

namespace msr
{
namespace airlib
{

    typedef msr::airlib_rpclib::CarRpcLibAdaptors CarRpcLibAdaptors;

    CarRpcLibServer::CarRpcLibServer(ApiProvider* api_provider, string server_address, uint16_t port)
        : RpcLibServerBase(api_provider, server_address, port)
    {
        (static_cast<rpc::server*>(getServer()))->bind("getCarState", [&](const std::string& vehicle_name) -> CarRpcLibAdaptors::CarState {
            return CarRpcLibAdaptors::CarState(getVehicleApi(vehicle_name)->getCarState());
        });

        (static_cast<rpc::server*>(getServer()))->bind("setCarControls", [&](const CarRpcLibAdaptors::CarControls& controls, const std::string& vehicle_name) -> void {
            getVehicleApi(vehicle_name)->setCarControls(controls.to());
        });
        (static_cast<rpc::server*>(getServer()))->bind("getCarControls", [&](const std::string& vehicle_name) -> CarRpcLibAdaptors::CarControls {
            return CarRpcLibAdaptors::CarControls(getVehicleApi(vehicle_name)->getCarControls());
        });
    }

    //required for pimpl
    CarRpcLibServer::~CarRpcLibServer()
    {
    }
}
} //namespace

#endif
#endif
