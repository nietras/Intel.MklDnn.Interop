#define _LIBCPP_DISABLE_VISIBILITY_ANNOTATIONS
#define _LIBCPP_HIDE_FROM_ABI

#include <mkldnn.h>
#include <mkldnn_config.h>
#include <mkldnn_debug.h>
#include <mkldnn_types.h>
#include <mkldnn_version.h>

extern "C" { void Intel_MklDnn_symbols1(void* __instance) { new (__instance) mkldnn_version_t(); } }
extern "C" { void Intel_MklDnn_symbols2(void* __instance, const mkldnn_version_t& _0) { new (__instance) mkldnn_version_t(_0); } }
mkldnn_version_t& (mkldnn_version_t::*Intel_MklDnn_symbols3)(const mkldnn_version_t&) = &mkldnn_version_t::operator=;
mkldnn_version_t& (mkldnn_version_t::*Intel_MklDnn_symbols4)(mkldnn_version_t&&) = &mkldnn_version_t::operator=;
extern "C" { void Intel_MklDnn_symbols5(mkldnn_version_t* __instance) { __instance->~mkldnn_version_t(); } }
extern "C" { void Intel_MklDnn_symbols6(void* __instance) { new (__instance) mkldnn_blocking_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols7(void* __instance, const mkldnn_blocking_desc_t& _0) { new (__instance) mkldnn_blocking_desc_t(_0); } }
mkldnn_blocking_desc_t& (mkldnn_blocking_desc_t::*Intel_MklDnn_symbols8)(const mkldnn_blocking_desc_t&) = &mkldnn_blocking_desc_t::operator=;
mkldnn_blocking_desc_t& (mkldnn_blocking_desc_t::*Intel_MklDnn_symbols9)(mkldnn_blocking_desc_t&&) = &mkldnn_blocking_desc_t::operator=;
extern "C" { void Intel_MklDnn_symbols10(mkldnn_blocking_desc_t* __instance) { __instance->~mkldnn_blocking_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols11(void* __instance) { new (__instance) mkldnn_wino_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols12(void* __instance, const mkldnn_wino_desc_t& _0) { new (__instance) mkldnn_wino_desc_t(_0); } }
mkldnn_wino_desc_t& (mkldnn_wino_desc_t::*Intel_MklDnn_symbols13)(const mkldnn_wino_desc_t&) = &mkldnn_wino_desc_t::operator=;
mkldnn_wino_desc_t& (mkldnn_wino_desc_t::*Intel_MklDnn_symbols14)(mkldnn_wino_desc_t&&) = &mkldnn_wino_desc_t::operator=;
extern "C" { void Intel_MklDnn_symbols15(mkldnn_wino_desc_t* __instance) { __instance->~mkldnn_wino_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols16(void* __instance) { new (__instance) mkldnn_rnn_packed_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols17(void* __instance, const mkldnn_rnn_packed_desc_t& _0) { new (__instance) mkldnn_rnn_packed_desc_t(_0); } }
mkldnn_rnn_packed_desc_t& (mkldnn_rnn_packed_desc_t::*Intel_MklDnn_symbols18)(const mkldnn_rnn_packed_desc_t&) = &mkldnn_rnn_packed_desc_t::operator=;
mkldnn_rnn_packed_desc_t& (mkldnn_rnn_packed_desc_t::*Intel_MklDnn_symbols19)(mkldnn_rnn_packed_desc_t&&) = &mkldnn_rnn_packed_desc_t::operator=;
extern "C" { void Intel_MklDnn_symbols20(mkldnn_rnn_packed_desc_t* __instance) { __instance->~mkldnn_rnn_packed_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols21(void* __instance) { new (__instance) mkldnn_memory_extra_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols22(void* __instance, const mkldnn_memory_extra_desc_t& _0) { new (__instance) mkldnn_memory_extra_desc_t(_0); } }
mkldnn_memory_extra_desc_t& (mkldnn_memory_extra_desc_t::*Intel_MklDnn_symbols23)(const mkldnn_memory_extra_desc_t&) = &mkldnn_memory_extra_desc_t::operator=;
mkldnn_memory_extra_desc_t& (mkldnn_memory_extra_desc_t::*Intel_MklDnn_symbols24)(mkldnn_memory_extra_desc_t&&) = &mkldnn_memory_extra_desc_t::operator=;
extern "C" { void Intel_MklDnn_symbols25(mkldnn_memory_extra_desc_t* __instance) { __instance->~mkldnn_memory_extra_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols26(void* __instance) { new (__instance) mkldnn_memory_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols27(void* __instance, const mkldnn_memory_desc_t& _0) { new (__instance) mkldnn_memory_desc_t(_0); } }
mkldnn_memory_desc_t& (mkldnn_memory_desc_t::*Intel_MklDnn_symbols28)(const mkldnn_memory_desc_t&) = &mkldnn_memory_desc_t::operator=;
mkldnn_memory_desc_t& (mkldnn_memory_desc_t::*Intel_MklDnn_symbols29)(mkldnn_memory_desc_t&&) = &mkldnn_memory_desc_t::operator=;
extern "C" { void Intel_MklDnn_symbols30(mkldnn_memory_desc_t* __instance) { __instance->~mkldnn_memory_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols31(void* __instance) { new (__instance) mkldnn_convolution_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols32(void* __instance, const mkldnn_convolution_desc_t& _0) { new (__instance) mkldnn_convolution_desc_t(_0); } }
mkldnn_convolution_desc_t& (mkldnn_convolution_desc_t::*Intel_MklDnn_symbols33)(const mkldnn_convolution_desc_t&) = &mkldnn_convolution_desc_t::operator=;
mkldnn_convolution_desc_t& (mkldnn_convolution_desc_t::*Intel_MklDnn_symbols34)(mkldnn_convolution_desc_t&&) = &mkldnn_convolution_desc_t::operator=;
extern "C" { void Intel_MklDnn_symbols35(mkldnn_convolution_desc_t* __instance) { __instance->~mkldnn_convolution_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols36(void* __instance) { new (__instance) mkldnn_shuffle_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols37(void* __instance, const mkldnn_shuffle_desc_t& _0) { new (__instance) mkldnn_shuffle_desc_t(_0); } }
mkldnn_shuffle_desc_t& (mkldnn_shuffle_desc_t::*Intel_MklDnn_symbols38)(const mkldnn_shuffle_desc_t&) = &mkldnn_shuffle_desc_t::operator=;
mkldnn_shuffle_desc_t& (mkldnn_shuffle_desc_t::*Intel_MklDnn_symbols39)(mkldnn_shuffle_desc_t&&) = &mkldnn_shuffle_desc_t::operator=;
extern "C" { void Intel_MklDnn_symbols40(mkldnn_shuffle_desc_t* __instance) { __instance->~mkldnn_shuffle_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols41(void* __instance) { new (__instance) mkldnn_eltwise_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols42(void* __instance, const mkldnn_eltwise_desc_t& _0) { new (__instance) mkldnn_eltwise_desc_t(_0); } }
mkldnn_eltwise_desc_t& (mkldnn_eltwise_desc_t::*Intel_MklDnn_symbols43)(const mkldnn_eltwise_desc_t&) = &mkldnn_eltwise_desc_t::operator=;
mkldnn_eltwise_desc_t& (mkldnn_eltwise_desc_t::*Intel_MklDnn_symbols44)(mkldnn_eltwise_desc_t&&) = &mkldnn_eltwise_desc_t::operator=;
extern "C" { void Intel_MklDnn_symbols45(mkldnn_eltwise_desc_t* __instance) { __instance->~mkldnn_eltwise_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols46(void* __instance) { new (__instance) mkldnn_softmax_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols47(void* __instance, const mkldnn_softmax_desc_t& _0) { new (__instance) mkldnn_softmax_desc_t(_0); } }
mkldnn_softmax_desc_t& (mkldnn_softmax_desc_t::*Intel_MklDnn_symbols48)(const mkldnn_softmax_desc_t&) = &mkldnn_softmax_desc_t::operator=;
mkldnn_softmax_desc_t& (mkldnn_softmax_desc_t::*Intel_MklDnn_symbols49)(mkldnn_softmax_desc_t&&) = &mkldnn_softmax_desc_t::operator=;
extern "C" { void Intel_MklDnn_symbols50(mkldnn_softmax_desc_t* __instance) { __instance->~mkldnn_softmax_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols51(void* __instance) { new (__instance) mkldnn_pooling_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols52(void* __instance, const mkldnn_pooling_desc_t& _0) { new (__instance) mkldnn_pooling_desc_t(_0); } }
mkldnn_pooling_desc_t& (mkldnn_pooling_desc_t::*Intel_MklDnn_symbols53)(const mkldnn_pooling_desc_t&) = &mkldnn_pooling_desc_t::operator=;
mkldnn_pooling_desc_t& (mkldnn_pooling_desc_t::*Intel_MklDnn_symbols54)(mkldnn_pooling_desc_t&&) = &mkldnn_pooling_desc_t::operator=;
extern "C" { void Intel_MklDnn_symbols55(mkldnn_pooling_desc_t* __instance) { __instance->~mkldnn_pooling_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols56(void* __instance) { new (__instance) mkldnn_lrn_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols57(void* __instance, const mkldnn_lrn_desc_t& _0) { new (__instance) mkldnn_lrn_desc_t(_0); } }
mkldnn_lrn_desc_t& (mkldnn_lrn_desc_t::*Intel_MklDnn_symbols58)(const mkldnn_lrn_desc_t&) = &mkldnn_lrn_desc_t::operator=;
mkldnn_lrn_desc_t& (mkldnn_lrn_desc_t::*Intel_MklDnn_symbols59)(mkldnn_lrn_desc_t&&) = &mkldnn_lrn_desc_t::operator=;
extern "C" { void Intel_MklDnn_symbols60(mkldnn_lrn_desc_t* __instance) { __instance->~mkldnn_lrn_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols61(void* __instance) { new (__instance) mkldnn_batch_normalization_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols62(void* __instance, const mkldnn_batch_normalization_desc_t& _0) { new (__instance) mkldnn_batch_normalization_desc_t(_0); } }
mkldnn_batch_normalization_desc_t& (mkldnn_batch_normalization_desc_t::*Intel_MklDnn_symbols63)(const mkldnn_batch_normalization_desc_t&) = &mkldnn_batch_normalization_desc_t::operator=;
mkldnn_batch_normalization_desc_t& (mkldnn_batch_normalization_desc_t::*Intel_MklDnn_symbols64)(mkldnn_batch_normalization_desc_t&&) = &mkldnn_batch_normalization_desc_t::operator=;
extern "C" { void Intel_MklDnn_symbols65(mkldnn_batch_normalization_desc_t* __instance) { __instance->~mkldnn_batch_normalization_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols66(void* __instance) { new (__instance) mkldnn_inner_product_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols67(void* __instance, const mkldnn_inner_product_desc_t& _0) { new (__instance) mkldnn_inner_product_desc_t(_0); } }
mkldnn_inner_product_desc_t& (mkldnn_inner_product_desc_t::*Intel_MklDnn_symbols68)(const mkldnn_inner_product_desc_t&) = &mkldnn_inner_product_desc_t::operator=;
mkldnn_inner_product_desc_t& (mkldnn_inner_product_desc_t::*Intel_MklDnn_symbols69)(mkldnn_inner_product_desc_t&&) = &mkldnn_inner_product_desc_t::operator=;
extern "C" { void Intel_MklDnn_symbols70(mkldnn_inner_product_desc_t* __instance) { __instance->~mkldnn_inner_product_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols71(void* __instance) { new (__instance) mkldnn_rnn_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols72(void* __instance, const mkldnn_rnn_desc_t& _0) { new (__instance) mkldnn_rnn_desc_t(_0); } }
mkldnn_rnn_desc_t& (mkldnn_rnn_desc_t::*Intel_MklDnn_symbols73)(const mkldnn_rnn_desc_t&) = &mkldnn_rnn_desc_t::operator=;
mkldnn_rnn_desc_t& (mkldnn_rnn_desc_t::*Intel_MklDnn_symbols74)(mkldnn_rnn_desc_t&&) = &mkldnn_rnn_desc_t::operator=;
extern "C" { void Intel_MklDnn_symbols75(mkldnn_rnn_desc_t* __instance) { __instance->~mkldnn_rnn_desc_t(); } }
extern "C" { void Intel_MklDnn_symbols76(void* __instance) { new (__instance) mkldnn_exec_arg_t(); } }
extern "C" { void Intel_MklDnn_symbols77(void* __instance, const mkldnn_exec_arg_t& _0) { new (__instance) mkldnn_exec_arg_t(_0); } }
mkldnn_exec_arg_t& (mkldnn_exec_arg_t::*Intel_MklDnn_symbols78)(const mkldnn_exec_arg_t&) = &mkldnn_exec_arg_t::operator=;
mkldnn_exec_arg_t& (mkldnn_exec_arg_t::*Intel_MklDnn_symbols79)(mkldnn_exec_arg_t&&) = &mkldnn_exec_arg_t::operator=;
extern "C" { void Intel_MklDnn_symbols80(mkldnn_exec_arg_t* __instance) { __instance->~mkldnn_exec_arg_t(); } }
